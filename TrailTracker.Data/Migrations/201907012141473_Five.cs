namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Trail", "Modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trail", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Trail", "ModifiedUtc");
        }
    }
}
