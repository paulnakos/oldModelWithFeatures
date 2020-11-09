namespace BeerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSeed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BeerUserProfiles", newName: "UserProfileBeers");
            DropPrimaryKey("dbo.UserProfileBeers");
            AddPrimaryKey("dbo.UserProfileBeers", new[] { "UserProfile_UserID", "Beer_BeerID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProfileBeers");
            AddPrimaryKey("dbo.UserProfileBeers", new[] { "Beer_BeerID", "UserProfile_UserID" });
            RenameTable(name: "dbo.UserProfileBeers", newName: "BeerUserProfiles");
        }
    }
}
