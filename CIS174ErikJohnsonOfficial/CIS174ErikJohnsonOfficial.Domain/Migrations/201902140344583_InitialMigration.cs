namespace CIS174ErikJohnsonOfficial.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Role = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.HighScores",
                c => new
                    {
                        HighScoreId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        Score = c.Int(nullable: false),
                        DateAttained = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HighScoreId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 30),
                        DateCreated = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 30),
                        Password = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.HighScores");
            DropTable("dbo.Developers");
        }
    }
}
