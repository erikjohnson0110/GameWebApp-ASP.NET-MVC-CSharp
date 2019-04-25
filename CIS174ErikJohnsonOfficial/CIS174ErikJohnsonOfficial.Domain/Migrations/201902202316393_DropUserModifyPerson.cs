namespace CIS174ErikJohnsonOfficial.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropUserModifyPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "UserName", c => c.String(maxLength: 30));
            AddColumn("dbo.People", "Password", c => c.String(maxLength: 30));
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 30),
                        Password = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "UserName");
        }
    }
}
