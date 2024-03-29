namespace TrailTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TrailMeet",
                c => new
                    {
                        TrailMeetID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        OfTrailType = c.Int(nullable: false),
                        Picture = c.String(),
                        JoinTrail = c.Boolean(nullable: false),
                        MeetTime = c.DateTime(nullable: false),
                        MeetComments = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        TrailTrackerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrailMeetID)
                .ForeignKey("dbo.Trail", t => t.TrailTrackerID, cascadeDelete: true)
                .Index(t => t.TrailTrackerID);
            
            CreateTable(
                "dbo.Trail",
                c => new
                    {
                        TrailTrackerID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        TrailName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Miles = c.Double(nullable: false),
                        Location = c.String(),
                        Difficulty = c.Int(nullable: false),
                        Elevation = c.Int(nullable: false),
                        SpotsAvailable = c.Int(nullable: false),
                        AverageTimeMinutes = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TrailTrackerID);
            
            CreateTable(
                "dbo.TrailsInfo",
                c => new
                    {
                        TrailInfoID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Rating = c.Int(nullable: false),
                        TrailComments = c.String(),
                        NoteableSites = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        TrailTrackerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrailInfoID)
                .ForeignKey("dbo.Trail", t => t.TrailTrackerID, cascadeDelete: true)
                .Index(t => t.TrailTrackerID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TrailsInfo", "TrailTrackerID", "dbo.Trail");
            DropForeignKey("dbo.TrailMeet", "TrailTrackerID", "dbo.Trail");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TrailsInfo", new[] { "TrailTrackerID" });
            DropIndex("dbo.TrailMeet", new[] { "TrailTrackerID" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.TrailsInfo");
            DropTable("dbo.Trail");
            DropTable("dbo.TrailMeet");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
        }
    }
}
