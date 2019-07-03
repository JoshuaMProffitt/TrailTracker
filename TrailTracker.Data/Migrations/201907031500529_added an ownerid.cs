namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanownerid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrailMeet",
                c => new
                    {
                        TrailTrackerID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        OfTrailType = c.Int(nullable: false),
                        Picture = c.String(),
                        JoinTrail = c.Boolean(nullable: false),
                        MeetTime = c.DateTime(nullable: false),
                        MeetComments = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TrailTrackerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrailMeet");
        }
    }
}
