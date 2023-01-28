namespace AspNewStudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        account_ID = c.Int(nullable: false),
                        account_FirstName = c.String(),
                        account_LastName = c.String(),
                        account_Password = c.String(),
                        account_EmailD = c.String(),
                        account_Gender = c.String(),
                        account_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        account_ID = c.Int(nullable: false),
                        account_FirstName = c.String(),
                        account_LastName = c.String(),
                        account_Password = c.String(),
                        account_EmailD = c.String(),
                        account_Gender = c.String(),
                        account_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientStudent",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorId })
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientStudent", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientStudent", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientStudent", new[] { "DoctorId" });
            DropIndex("dbo.PatientStudent", new[] { "PatientId" });
            DropTable("dbo.PatientStudent");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
        }
    }
}
