namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigraton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                        Trail_TrailTrackerID = c.Int(),
                        TrailMeet_TrailMeetID = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Trail", t => t.Trail_TrailTrackerID)
                .ForeignKey("dbo.TrailMeet", t => t.TrailMeet_TrailMeetID)
                .Index(t => t.Trail_TrailTrackerID)
                .Index(t => t.TrailMeet_TrailMeetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "TrailMeet_TrailMeetID", "dbo.TrailMeet");
            DropForeignKey("dbo.Photo", "Trail_TrailTrackerID", "dbo.Trail");
            DropIndex("dbo.Photo", new[] { "TrailMeet_TrailMeetID" });
            DropIndex("dbo.Photo", new[] { "Trail_TrailTrackerID" });
            DropTable("dbo.Photo");
        }
    }
}
