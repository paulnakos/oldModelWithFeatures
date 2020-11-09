namespace BeerV1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BeerV1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerV1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeerV1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var beers = new List<Beer>
            //{
            //    new Beer {BeerID=1,Name = "Heineken", Family = "Lager", Type = "Peripterompyra",Color="Y", IBU = 5, ABV = 5.4d},
            //    new Beer {BeerID=2,Name = "Amstel", Family = "Lager", Type = "Giati etsi sas aresei", Color="Y", IBU = 3, ABV = 2.7},
            //    new Beer {BeerID=3,Name = "kilkenny", Family = "Amber Ale", Type = "Goustoza", Color="Y", IBU = 7, ABV = 8.2},
            //    new Beer {BeerID=4,Name = "Leffe", Family = "Belgian Ale", Type = "Blondie",Color="Y", IBU = 6, ABV = 4.7},
            //    new Beer {BeerID=5,Name = "Samichlaus", Family = "Amber Ale Monasterial",Color="R", Type = "RedHead", IBU = 8, ABV = 14},
            //    new Beer {BeerID=6,Name = "Gates of S'mordor", Family = "Stout", Type = "Imperial / Double Pastry", Color="B", IBU = 6, ABV = 12},
            //    new Beer {BeerID=7,Name = "OFS017", Family = "IPA", Type = "New England",Color="R", IBU = 7, ABV = 4}
            //};

            //beers.ForEach(b => context.Beers.Add(b));
            //context.SaveChanges();
        }
    }
}
