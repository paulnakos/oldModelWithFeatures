namespace BeerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLocationName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserLocationID", "dbo.UserLocations");
            DropIndex("dbo.Users", new[] { "UserLocationID" });
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            AddColumn("dbo.Users", "LocationID", c => c.Int());
            CreateIndex("dbo.Users", "LocationID");
            AddForeignKey("dbo.Users", "LocationID", "dbo.Locations", "LocationID");
            DropColumn("dbo.Users", "UserLocationID");
            DropTable("dbo.UserLocations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserLocations",
                c => new
                    {
                        UserLocationID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        PostalCode = c.Int(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.UserLocationID);
            
            AddColumn("dbo.Users", "UserLocationID", c => c.Int());
            DropForeignKey("dbo.Users", "LocationID", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "LocationID" });
            DropColumn("dbo.Users", "LocationID");
            DropTable("dbo.Locations");
            CreateIndex("dbo.Users", "UserLocationID");
            AddForeignKey("dbo.Users", "UserLocationID", "dbo.UserLocations", "UserLocationID");
        }
    }
}
