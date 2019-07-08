namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrailsInfo", "TrailName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrailsInfo", "TrailName");
        }
    }
}
