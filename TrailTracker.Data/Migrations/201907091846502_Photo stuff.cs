namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photostuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photo", "Trail_TrailTrackerID", "dbo.Trail");
            DropForeignKey("dbo.Photo", "TrailMeet_TrailMeetID", "dbo.TrailMeet");
            DropIndex("dbo.Photo", new[] { "Trail_TrailTrackerID" });
            DropIndex("dbo.Photo", new[] { "TrailMeet_TrailMeetID" });
            RenameColumn(table: "dbo.Photo", name: "TrailMeet_TrailMeetID", newName: "TrailMeetID");
            AlterColumn("dbo.Photo", "TrailMeetID", c => c.Int(nullable: false));
            CreateIndex("dbo.Photo", "TrailMeetID");
            AddForeignKey("dbo.Photo", "TrailMeetID", "dbo.TrailMeet", "TrailMeetID", cascadeDelete: true);
            DropColumn("dbo.Photo", "PostID");
            DropColumn("dbo.Photo", "Trail_TrailTrackerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photo", "Trail_TrailTrackerID", c => c.Int());
            AddColumn("dbo.Photo", "PostID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Photo", "TrailMeetID", "dbo.TrailMeet");
            DropIndex("dbo.Photo", new[] { "TrailMeetID" });
            AlterColumn("dbo.Photo", "TrailMeetID", c => c.Int());
            RenameColumn(table: "dbo.Photo", name: "TrailMeetID", newName: "TrailMeet_TrailMeetID");
            CreateIndex("dbo.Photo", "TrailMeet_TrailMeetID");
            CreateIndex("dbo.Photo", "Trail_TrailTrackerID");
            AddForeignKey("dbo.Photo", "TrailMeet_TrailMeetID", "dbo.TrailMeet", "TrailMeetID");
            AddForeignKey("dbo.Photo", "Trail_TrailTrackerID", "dbo.Trail", "TrailTrackerID");
        }
    }
}
