namespace BeerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLocationIDAddRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "LocationID", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "LocationID" });
            AlterColumn("dbo.Users", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "LocationID");
            AddForeignKey("dbo.Users", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "LocationID", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "LocationID" });
            AlterColumn("dbo.Users", "LocationID", c => c.Int());
            CreateIndex("dbo.Users", "LocationID");
            AddForeignKey("dbo.Users", "LocationID", "dbo.Locations", "LocationID");
        }
    }
}
