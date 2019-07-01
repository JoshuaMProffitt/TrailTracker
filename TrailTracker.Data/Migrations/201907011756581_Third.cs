namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Trail", "Created", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Trail", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Trail", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trail", "Description", c => c.String());
            DropColumn("dbo.Trail", "Modified");
            DropColumn("dbo.Trail", "Created");
            DropColumn("dbo.Trail", "OwnerID");
        }
    }
}
