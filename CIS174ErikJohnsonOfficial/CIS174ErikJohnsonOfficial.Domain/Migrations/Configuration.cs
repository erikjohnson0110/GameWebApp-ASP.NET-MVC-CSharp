namespace CIS174ErikJohnsonOfficial.Domain.Migrations
{
    using CIS174ErikJohnsonOfficial.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CIS174ErikJohnsonOfficial.Domain.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CIS174ErikJohnsonOfficial.Domain.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            // Populate High Scores Table
            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("2b27c6e4-112a-482d-9873-fad66b7fd0b5"),
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Score = 150000000,
                DateAttained = new DateTime(2019, 01, 10)
            });

            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("e50cc485-59f4-4258-868b-9a092b16004a"),
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Score = 140000000,
                DateAttained = new DateTime(2019, 01, 10)
            });

            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("ffc9a19e-2da5-4d5d-8f25-847ffdc7a232"),
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Score = 130000000,
                DateAttained = new DateTime(2019, 01, 10)
            });

            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("35939766-3ad6-443d-8f98-1159fbac5fab"),
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Score = 120000000,
                DateAttained = new DateTime(2019, 01, 10)
            });

            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("1be31b36-83bf-4c94-881a-b46521ff2c99"),
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Score = 110000000,
                DateAttained = new DateTime(2019, 01, 10)
            });

            //Populate People
            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                FirstName = "Erik",
                LastName = "Johnson",
                Email = "eejohnson1@dmacc.edu",
                DateCreated = DateTime.Now
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("fda5f043-e65c-46d4-8fbe-4dbed1f43a27"),
                FirstName = "Tyler",
                LastName = "Ross",
                Email = "tjross@dmacc.edu",
                DateCreated = DateTime.Now
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("e65ec64d-faf8-43f5-bc5a-598aae5f37eb"),
                FirstName = "Adam",
                LastName = "Cbzski",
                Email = "acbzski@dmacc.edu",
                DateCreated = DateTime.Now
            });

            //Populate Developers
            context.Developers.AddOrUpdate(new Developer
            {
                DeveloperId = Guid.Parse("904c75bf-e8d4-4ab8-b527-13bcabdb4657"),
                Name = "Erik Johnson",
                Email = "eejohnson1@dmacc.edu",
                Role = "Lead Developer"
            });

            context.Developers.AddOrUpdate(new Developer
            {
                DeveloperId = Guid.Parse("fda5f043-e65c-46d4-8fbe-4dbed1f43a27"),
                Name = "Tyler Ross",
                Email = "tjross@dmacc.edu",
                Role = "Effects Developer"
            });

            context.Developers.AddOrUpdate(new Developer
            {
                DeveloperId = Guid.Parse("e65ec64d-faf8-43f5-bc5a-598aae5f37eb"),
                Name = "Adam Cbzski",
                Email = "acbzski@dmacc.edu",
                Role = "Enemy Developer"
            });


        }
    }
}
