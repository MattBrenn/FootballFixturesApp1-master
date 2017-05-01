namespace FootballFixturesApp1.MatchContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Report", "AReport", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Report", "AReport", c => c.String(nullable: false));
        }
    }
}
