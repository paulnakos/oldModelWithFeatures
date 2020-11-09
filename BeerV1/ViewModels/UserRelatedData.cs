using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerV1.Models;

namespace BeerV1.ViewModels
{
    public class UserRelatedData
    {
        public IEnumerable<UserProfile> UserProfiles { get; set; }
        public IEnumerable<Beer> FavoriteBeers { get; set; }
        public int UserID { get; set; }
    }
}