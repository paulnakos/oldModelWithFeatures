namespace BeerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        BeerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Type = c.String(),
                        Color = c.String(),
                        IBU = c.Int(nullable: false),
                        ABV = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BeerID);
            
            CreateTable(
                "dbo.BeerUserProfiles",
                c => new
                    {
                        Beer_BeerID = c.Int(nullable: false),
                        UserProfile_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Beer_BeerID, t.UserProfile_UserID })
                .ForeignKey("dbo.Beers", t => t.Beer_BeerID, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserID, cascadeDelete: true)
                .Index(t => t.Beer_BeerID)
                .Index(t => t.UserProfile_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserID", "dbo.Users");
            DropForeignKey("dbo.BeerUserProfiles", "UserProfile_UserID", "dbo.UserProfiles");
            DropForeignKey("dbo.BeerUserProfiles", "Beer_BeerID", "dbo.Beers");
            DropIndex("dbo.BeerUserProfiles", new[] { "UserProfile_UserID" });
            DropIndex("dbo.BeerUserProfiles", new[] { "Beer_BeerID" });
            DropIndex("dbo.UserProfiles", new[] { "UserID" });
            DropTable("dbo.BeerUserProfiles");
            DropTable("dbo.Beers");
            DropTable("dbo.UserProfiles");
        }
    }
}
