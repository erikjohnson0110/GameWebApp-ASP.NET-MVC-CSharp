using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Domain.Entities;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators
{
    public class HighScoreOrchestrator : IHighScoreOrchestrator
    {
        private readonly DataContext _highScoreContext;
        private IErrorOrchestrator _errorOrchestrator;

        public HighScoreOrchestrator(DataContext dc, IErrorOrchestrator eo)
        {
            _highScoreContext = dc;
            _errorOrchestrator = eo;
        }

        // show all scores stored in DB
        public List<HighScoreViewModel> GetAllHighScores()
        {
            try
            {
                var highScores = (from hs in _highScoreContext.HighScores
                                  join p in _highScoreContext.People on hs.PersonId equals p.PersonId
                                  orderby hs.Score descending
                                  select new HighScoreViewModel
                                  {
                                      UserName = p.UserName,
                                      Score = hs.Score,
                                      DateAttained = hs.DateAttained
                                  }).ToList();


                return highScores;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);

                return null;
            }
        }

        public List<HighScoreViewModel> GetTopTenScores()
        {
            try
            {
                var highScores = (from hs in _highScoreContext.HighScores
                                  join p in _highScoreContext.People on hs.PersonId equals p.PersonId
                                  orderby hs.Score descending
                                  select new HighScoreViewModel
                                  {
                                      UserName = p.UserName,
                                      Score = hs.Score,
                                      DateAttained = hs.DateAttained
                                  }).Take(10).ToList();

                return highScores;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }

        // Get high score for 1 user
        public HighScoreViewModel GetUserHighScore(Guid id)
        {
            try
            {
                var highScore = (from hs in _highScoreContext.HighScores
                                join p in _highScoreContext.People on hs.PersonId equals p.PersonId
                                where p.PersonId == id
                                orderby hs.Score descending
                                select new HighScoreViewModel
                                 {
                                  UserName = p.UserName,
                                  Score = hs.Score,
                                   DateAttained = hs.DateAttained
                                 }).Take(1).Single();

                return highScore;
            }
            catch (Exception ex)
            {
                // this is for testing my logic above.
                // log error in Error DB
                _errorOrchestrator.newError(ex);

                // return blank View Model -- this could change to null, but I wanted to be 
                // certain that the catch block was executing, and not throwing an error outside of the try block
                // elsewhere in my logic.
                return new HighScoreViewModel
                {
                    UserName = "Fail",
                    Score = 0000,
                    DateAttained = DateTime.Now
                };
            }
        }

        public bool setHighScore(Guid id, int newScore)
        {
            try
            {
                HighScore current = (from hs in _highScoreContext.HighScores
                                     where hs.PersonId == id
                                     orderby hs.Score descending
                                     select hs).SingleOrDefault();
                if (current == null)
                {
                    current = new HighScore();
                    current.DateAttained = DateTime.Now;
                    current.HighScoreId = Guid.NewGuid();
                    current.PersonId = id;
                    current.Score = newScore;
                    _highScoreContext.HighScores.Add(current);
                    _highScoreContext.SaveChanges();
                    return true;

                }

                if (current.Score < newScore)
                {
                    current.Score = newScore;
                    current.DateAttained = DateTime.Now;
                    _highScoreContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return false;
            }
        }
    }
}
