using CIS174ErikJohnsonOfficial.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174ErikJohnsonOfficial.Shared.Orchestrators.Interfaces
{
    public interface IHighScoreOrchestrator
    {
        List<HighScoreViewModel> GetAllHighScores();
        List<HighScoreViewModel> GetTopTenScores();
        HighScoreViewModel GetUserHighScore(Guid id);
        bool setHighScore(Guid id, int newScore);
    }
}
