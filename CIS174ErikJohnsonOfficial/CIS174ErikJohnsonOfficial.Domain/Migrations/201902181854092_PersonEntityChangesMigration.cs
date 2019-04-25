namespace CIS174ErikJohnsonOfficial.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonEntityChangesMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhoneNumber", c => c.String(maxLength: 10));
            AddColumn("dbo.People", "Gender", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Gender");
            DropColumn("dbo.People", "PhoneNumber");
        }
    }
}
