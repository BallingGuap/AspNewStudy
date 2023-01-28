namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientStudent", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientStudent", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientStudent", new[] { "PatientId" });
            DropIndex("dbo.PatientStudent", new[] { "DoctorId" });
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(),
                        EmailD = c.String(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 15),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientStudent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientStudent",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorId });
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        account_ID = c.Int(nullable: false),
                        account_FirstName = c.String(nullable: false, maxLength: 15),
                        account_LastName = c.String(nullable: false, maxLength: 15),
                        account_Password = c.String(),
                        account_EmailD = c.String(nullable: false),
                        account_Gender = c.String(nullable: false, maxLength: 15),
                        account_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        account_ID = c.Int(nullable: false),
                        account_FirstName = c.String(nullable: false, maxLength: 15),
                        account_LastName = c.String(nullable: false, maxLength: 15),
                        account_Password = c.String(),
                        account_EmailD = c.String(nullable: false),
                        account_Gender = c.String(nullable: false, maxLength: 15),
                        account_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Accounts");
            CreateIndex("dbo.PatientStudent", "DoctorId");
            CreateIndex("dbo.PatientStudent", "PatientId");
            AddForeignKey("dbo.PatientStudent", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientStudent", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
