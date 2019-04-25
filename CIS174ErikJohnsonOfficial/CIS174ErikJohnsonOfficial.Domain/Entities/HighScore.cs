using System;

namespace CIS174ErikJohnsonOfficial.Domain.Entities
{
    public class HighScore
    {
        public Guid HighScoreId { get; set; }
        public Guid PersonId { get; set; }
        public int Score { get; set; }
        public DateTime DateAttained { get; set; }
    }
}
