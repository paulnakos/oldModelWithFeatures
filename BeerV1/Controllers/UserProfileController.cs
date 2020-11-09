using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerV1.MockRepositories;
using BeerV1.Models;
using BeerV1.ViewModels;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;
using System.Data.Entity;

namespace BeerV1.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly MockRepository mockRepository = new MockRepository();
        private ApplicationDbContext context;

        public UserProfileController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult Index(int? id)
        {
            var userProfiles = context.UserProfiles
                .Include(u => u.User.Location)
                .Include(u => u.Beers).ToList();

            var viewModel = new UserRelatedData();

            viewModel.UserProfiles = userProfiles;

            if (id.HasValue)
            {
                viewModel.FavoriteBeers = userProfiles
                    .Single(u => u.UserID == id).Beers;
                viewModel.UserID = (int)id;
            }


            return View(viewModel);
        }


        public ActionResult UserProfile(int? id)
        {
            var user = context.UserProfiles
                .Include(u => u.User.Location)
                .Include(u => u.Beers)
                .Single(u => u.UserID == id);

            return View(user);
        }

        //Get
        public ActionResult New()
        {
            var viewModel = new UserFormViewModel
            {
                Locations = context.Locations
            };
            
            return View("UserForm", viewModel);
        }

        private List<AddUserBeersViewModel> PopulateUserBeers(UserProfile userProfile, int[] selectedBeers,bool edit) // added selectedBeers to work correclty with validations
        {
            var beersDb = context.Beers;
            var userBeers = userProfile.Beers;
            var userBeersHS = new HashSet<int>();

            if (edit == true)
                userBeersHS = new HashSet<int>(userBeers.Select(b => b.BeerID));
            else
            {
                if (selectedBeers == null)
                    userBeersHS = new HashSet<int>();
                else
                    userBeersHS = selectedBeers.ToHashSet();
            }
               // userBeersHS = selectedBeers.ToHashSet() ?? new HashSet<int>();

            var chosenBeers = new List<AddUserBeersViewModel>();
            foreach (var beer in beersDb)
            {
                chosenBeers.Add(new AddUserBeersViewModel
                {
                    BeerId = beer.BeerID,
                    Name = beer.Name,
                    Chosen = userBeersHS.Contains(beer.BeerID)
                });
            }

            return chosenBeers;
        }

        //Get
        public ActionResult Edit(int id)
        {
            var user = context.Users
                .Include(u => u.Location)
                .Include(u => u.UserProfile.Beers)
                .SingleOrDefault(u => u.UserID == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel
            {
                User = user,
                Beers = context.Beers,
                ChosenBeers = new List<AddUserBeersViewModel>(),
                Locations = context.Locations
            };

            if (user.UserProfile.Beers != null)
                viewModel.ChosenBeers = PopulateUserBeers(user.UserProfile,null,true);

            return View("UserForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(UserFormViewModel viewModel,int[] selectedBeers)
        {
            
            if (!ModelState.IsValid)
            {
                viewModel.Locations = context.Locations;
                viewModel.User.UserProfile = context.UserProfiles.Include(u => u.Beers).SingleOrDefault(u => u.UserID == viewModel.User.UserID);
                if (viewModel.User.UserID != 0) // if its not new user
                    viewModel.ChosenBeers = PopulateUserBeers(viewModel.User.UserProfile,selectedBeers,false);
                return View("UserForm", viewModel);
            }

            if (viewModel.User.UserID == 0) // create user
            {

                context.Users.Add(viewModel.User);
                context.UserProfiles.Add(new UserProfile { UserID = 0 });
            }
            else // update user
            {
                var userDb = context.Users.Include(u => u.UserProfile.Beers).Include(u => u.Location).Single(u => u.UserID == viewModel.User.UserID);
                AddUserBeers(userDb, selectedBeers);

                userDb.FirstName = viewModel.User.FirstName;
                userDb.LastName = viewModel.User.LastName;
                userDb.Gender = viewModel.User.Gender;
                userDb.BirthDate = viewModel.User.BirthDate;
                userDb.LocationID = viewModel.User.LocationID;
            }

            context.SaveChanges();

            return RedirectToAction("index", "userprofile");
        }

        private void AddUserBeers(User user,int[] selectedBeers)
        {
            if (selectedBeers == null)
            {
                user.UserProfile.Beers = null;
                return;
            }

            var userBeers = user.UserProfile.Beers.Select(b => b.BeerID);
            foreach (var beer in context.Beers)
            {
                if(selectedBeers.Contains(beer.BeerID))
                {
                    if (!userBeers.Contains(beer.BeerID))
                        user.UserProfile.Beers.Add(beer);
                }
                else
                {
                    if (userBeers.Contains(beer.BeerID))
                        user.UserProfile.Beers.Remove(beer);
                }

            }
        }
        // GET: UserProfile
        //public ActionResult Index(int? id)
        //{
        //    var viewModel = new UserRelatedData();


        //    var userProfiles = mockRepository.GetUserProfiles();

        //    viewModel.UserProfiles = userProfiles;

        //    if (id != null)
        //    {
        //        var favoriteBeersID = mockRepository.GetUserBeers().Where(u => u.UserID == id); //list of user beers
        //        var beers = new List<Beer>();

        //        foreach (var beer in favoriteBeersID)
        //        {
        //            beers.Add(mockRepository.CreateBeerList().Single(b => b.BeerID == beer.BeerID)); //find beers from beerID
        //        }

        //        viewModel.FavoriteBeers = beers;
        //        ViewBag.UserID = id;
        //    }

        //    return View(viewModel);
        //}




    }
}