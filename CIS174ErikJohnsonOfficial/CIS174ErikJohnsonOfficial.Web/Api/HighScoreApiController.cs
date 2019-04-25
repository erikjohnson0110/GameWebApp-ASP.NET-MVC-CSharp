using CIS174ErikJohnsonOfficial.Domain;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators;
using CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces;
using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CIS174ErikJohnsonOfficial.Web.Api
{
    //[Route("api/v1/highscores")]
    public class HighScoreApiController : ApiController
    {
        private IHighScoreOrchestrator _highScoreOrchestrator;
        private IErrorOrchestrator _errorOrchestrator;

        public HighScoreApiController(IHighScoreOrchestrator ho, IErrorOrchestrator eo)
        {
            _highScoreOrchestrator = ho;
            _errorOrchestrator = eo;
        }

        [HttpGet]
        public List<HighScoreViewModel> GetAllHighScores()
        {
            try
            {
                var scores = _highScoreOrchestrator.GetAllHighScores();

                return scores;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }

        public List<HighScoreViewModel> GetTopTen()
        {
            try
            {
                var scores = _highScoreOrchestrator.GetTopTenScores();
                return scores;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }

        [HttpGet]
        public HighScoreViewModel GetUserHighScore(String param1)
        {
            try
            {
                Guid gid = Guid.Parse(param1);
                var score = _highScoreOrchestrator.GetUserHighScore(gid);

                return score;
            }
            catch (Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return null;
            }
        }

        [HttpPost]
        public String SetUserHighScore(String param1, int param2)
        {
            try
            {
                Guid gid = Guid.Parse(param1);
                if (_highScoreOrchestrator.setHighScore(gid, param2))
                {
                    return "Success!";
                }
                else
                {
                    return "Fail";
                }
            }
            catch(Exception ex)
            {
                _errorOrchestrator.newError(ex);
                return "Exception";
            }
        }
    }
}