using System;
using AutoMoq;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using CIS174ErikJohnsonOfficial.Web.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Collections.Generic;

namespace CIS174ErikJohnsonOfficial.Test
{
    [TestClass]
    public class HighScoreApiTest
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        // Assignment 11.3 - Part One
        // If you have not already done so create an API method that returns your high score 
        // Create tests that set up high scores and confirm the correct scores are being returned by this method in the correct numerical order
        [TestMethod]
        public void GetUserHighScoreReturnsCorrectValueExpectsCorrectValueAssertsTrue()
        {
            //Arrange
            // set up high score
            Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");
            HighScoreViewModel testUserViewModel = new HighScoreViewModel
            {
                UserName = "ejohnse",
                DateAttained = new DateTime(2019, 04, 01),
                Score = 1000
            };

            _mocker.GetMock<IHighScoreOrchestrator>().Setup(x => x.GetUserHighScore(testId)).Returns(testUserViewModel);

            var TestApiController = _mocker.Create<HighScoreApiController>();

            //Act
            // confirm the correct scores are being returned.
            var testResult = TestApiController.GetUserHighScore(testId.ToString());
            //Assert
            Assert.AreEqual(testUserViewModel, testResult);
        }

        [TestMethod]
        public void GetUserHighScoreReturnsCorrectValueExpectsWrongValueAssertsFalse()
        {
            //Arrange
            Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");
            HighScoreViewModel validHighScore = new HighScoreViewModel
            {
                UserName = "ejohnse",
                DateAttained = new DateTime(2019, 04, 01),
                Score = 1000
            };

            HighScoreViewModel notValidHighScore = new HighScoreViewModel
            {
                UserName = "Barry",
                DateAttained = new DateTime(2018, 04, 01),
                Score = 900
            };

            _mocker.GetMock<IHighScoreOrchestrator>().Setup(x => x.GetUserHighScore(testId)).Returns(validHighScore);

            var TestApiController = _mocker.Create<HighScoreApiController>();
            //Act
            var testResult = TestApiController.GetUserHighScore(testId.ToString());

            //Assert
            Assert.AreNotEqual(testResult, notValidHighScore);

        }


        // If you have not already done so create an API method that accepts a new score for a player 
        // It should determine if that is their high score or not 
        // It should set the player's new high score ONLY if it is a new high score
        // Create positive and negative unit tests on this method for if it is a new high score and if it gets set

        [TestMethod]
        public void SetUserHighScoreValidHighScoreAssertsEqual()
        {
            // Arrange
            // create guid for the test user
            Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");

            _mocker.GetMock<IHighScoreOrchestrator>().Setup(x => x.setHighScore(testId, 1100)).Returns(true);

            var TestApiController = _mocker.Create<HighScoreApiController>();

            // Act
            var result = TestApiController.SetUserHighScore(testId.ToString(), 1100);

            // Assert
            Assert.AreEqual("Success!", result);
        }

        [TestMethod]
        public void SetUserHighScoreInvalidHighScoreAssertsNotEqual()
        {
            // Arrange
            // create guid for the test user
            Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");

            _mocker.GetMock<IHighScoreOrchestrator>().Setup(x => x.setHighScore(testId, 1100)).Returns(true);

            var TestApiController = _mocker.Create<HighScoreApiController>();

            // Act
            var result = TestApiController.SetUserHighScore(testId.ToString(), 1000);

            // Assert
            Assert.AreEqual("Fail", result);
        }


        // Create an integration test (larger unit test) which does the following: 
        // Sets up high scores
        // Calls the method that updates a player's high score (this should place them on the leader board when they previously were not)
        // Calls that method that returns the leader board
        // Validate that the player we just updated is returned in the correct place on the leader board
        // Validate that all previously existing players show up in the newly correct place on the leader board 
        // (if player 1 was 5th and the new player is now 4th then player 1 should be in 6th)
        [TestMethod]
        public void ApiIntegrationTest()
        {
            Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");
            String testIdString = "904c75bf-e8d4-4ab8-b527-13bcabdb4657";
            // set up high scores table
            var api = _mocker.Create<HighScoreApiController>();
            var allScoresBefore = api.GetAllHighScores();

            // set new high score
            api.SetUserHighScore(testIdString, 200000000);

            // return all high scores
            var allScoresAfter = api.GetAllHighScores();

            // validate that player is appropriately placed
            int playerScorePosition = -1;
            for (int i =0; i < allScoresAfter.Count; i++)
            {
                var current = allScoresAfter[i];
                if (current.UserName.Equals("ejohnse"))
                {
                    playerScorePosition = i;
                }
            }

            // Value inserted should be at index zero since it was largest
            Assert.AreEqual(0, playerScorePosition);

        }
        /*
         
        Guid testId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657");
            // set up high scores table
            List<HighScoreViewModel> theDb = new List<HighScoreViewModel>();
            theDb.Add(
                new HighScoreViewModel
                {
                    UserName = "bobby",
                    Score = 500,
                    DateAttained = new DateTime(2018, 10, 20)
                });

            theDb.Add(
                new HighScoreViewModel
                {
                    UserName = "sandy",
                    Score = 600,
                    DateAttained = new DateTime(2018, 11, 12)
                });

            theDb.Add(
                new HighScoreViewModel
                {
                    UserName = "rowdy rod",
                    Score = 800,
                    DateAttained = new DateTime(2019, 02, 01)
                });

            _mocker.GetMock<IHighScoreOrchestrator>().Setup(x => x.setHighScore(testId, 1100)).Returns(true);

            var TestApiController = _mocker.Create<HighScoreApiController>();

            // set new player high score
            HighScoreViewModel playerScore = new HighScoreViewModel
            {
                UserName = "ejohnse",
                Score = 1100,
                DateAttained = new DateTime(2019, 04, 03)
            };
            var result = TestApiController.SetUserHighScore(testId.ToString(), playerScore.Score);
         
         */
    }
}
