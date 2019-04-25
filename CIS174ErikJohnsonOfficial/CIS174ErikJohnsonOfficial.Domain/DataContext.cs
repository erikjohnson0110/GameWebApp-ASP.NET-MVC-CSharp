using CIS174ErikJohnsonOfficial.Domain.Entities;
using System.Data.Entity;

namespace CIS174ErikJohnsonOfficial.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<HighScore> HighScores { get; set; }
        public DbSet<Error> Errors { get; set; }
    }
}
