namespace CIS174ErikJohnsonOfficial.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ErrorID = c.Guid(nullable: false),
                        ErrorDateTime = c.DateTime(nullable: false),
                        ErrorMessage = c.String(),
                        StackTrace = c.String(),
                        InnerExceptions = c.String(),
                    })
                .PrimaryKey(t => t.ErrorID);
            
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(maxLength: 10));
            DropTable("dbo.Errors");
        }
    }
}
