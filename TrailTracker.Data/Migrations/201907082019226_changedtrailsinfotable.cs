namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtrailsinfotable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrailsInfo", "TrailName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrailsInfo", "TrailName", c => c.String());
        }
    }
}
