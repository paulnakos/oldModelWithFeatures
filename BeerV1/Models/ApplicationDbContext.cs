using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerV1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public new DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }


        public ApplicationDbContext()
            : base("BeerV2Context", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}