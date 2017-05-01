namespace FootballFixturesApp1.MatchContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fixture",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        TeamOne = c.String(nullable: false),
                        TeamTwo = c.String(nullable: false),
                        Result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        AReport = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportFixture",
                c => new
                    {
                        Report_ID = c.String(nullable: false, maxLength: 128),
                        Fixture_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Report_ID, t.Fixture_ID })
                .ForeignKey("dbo.Report", t => t.Report_ID, cascadeDelete: true)
                .ForeignKey("dbo.Fixture", t => t.Fixture_ID, cascadeDelete: true)
                .Index(t => t.Report_ID)
                .Index(t => t.Fixture_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportFixture", "Fixture_ID", "dbo.Fixture");
            DropForeignKey("dbo.ReportFixture", "Report_ID", "dbo.Report");
            DropIndex("dbo.ReportFixture", new[] { "Fixture_ID" });
            DropIndex("dbo.ReportFixture", new[] { "Report_ID" });
            DropTable("dbo.ReportFixture");
            DropTable("dbo.Report");
            DropTable("dbo.Fixture");
        }
    }
}
