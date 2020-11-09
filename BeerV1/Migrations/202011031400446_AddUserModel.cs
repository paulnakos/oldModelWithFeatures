namespace BeerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Gender = c.Int(),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        UserLocationID = c.Int(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserLocations", t => t.UserLocationID)
                .Index(t => t.UserLocationID);
            
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        EmailAdress = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserLocationID", "dbo.UserLocations");
            DropForeignKey("dbo.UserCredentials", "UserID", "dbo.Users");
            DropIndex("dbo.UserCredentials", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "UserLocationID" });
            DropTable("dbo.UserLocations");
            DropTable("dbo.UserCredentials");
            DropTable("dbo.Users");
        }
    }
}
