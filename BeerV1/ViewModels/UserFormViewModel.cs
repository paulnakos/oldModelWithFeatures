using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BeerV1.Models;

namespace BeerV1.ViewModels
{
    public class UserFormViewModel
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<Beer> Beers { get; set; }

        [Display(Name = "Favorite Beers") ]
        public IEnumerable<AddUserBeersViewModel> ChosenBeers { get; set; }

        [Display(Name = "Address")]
        public IEnumerable<Location> Locations { get; set; }

        public UserFormViewModel()
        {
            User = new User();
            UserProfile = new UserProfile();
            UserProfile.UserID = User.UserID;
            
        }
    }
}