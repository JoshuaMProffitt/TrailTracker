namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerIDDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrailsInfo",
                c => new
                    {
                        TrailTrackerID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Rating = c.Int(nullable: false),
                        TrailComments = c.String(),
                        NoteableSites = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TrailTrackerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrailsInfo");
        }
    }
}
