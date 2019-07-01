namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trail", "Description");
        }
    }
}
