namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Trail", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trail", "Created", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Trail", "CreatedUtc");
        }
    }
}
