namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project_Migration_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                        EmailD = c.String(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
