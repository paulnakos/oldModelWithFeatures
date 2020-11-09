using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerV1.Models;
using BeerV1.ViewModels;

namespace BeerV1.MockRepositories
{
    public class MockRepository
    {
        public IEnumerable<Beer> CreateBeerList()
        {
            return new List<Beer>
            {
                new Beer {BeerID=1,Name = "Heineken", Family = "Lager", Type = "Peripterompyra",Color="Y", IBU = 5, ABV = 5.4d},
                new Beer {BeerID=2,Name = "Amstel", Family = "Lager", Type = "Giati etsi sas aresei", Color="Y", IBU = 3, ABV = 2.7},
                new Beer {BeerID=3,Name = "kilkenny", Family = "Amber Ale", Type = "Goustoza", Color="Y", IBU = 7, ABV = 8.2},
                new Beer {BeerID=4,Name = "Leffe", Family = "Belgian Ale", Type = "Blondie",Color="Y", IBU = 6, ABV = 4.7},
                new Beer {BeerID=5,Name = "Samichlaus", Family = "Amber Ale Monasterial",Color="R", Type = "RedHead", IBU = 8, ABV = 14},
                new Beer {BeerID=6,Name = "Gates of S'mordor", Family = "Stout", Type = "Imperial / Double Pastry", Color="B", IBU = 6, ABV = 12},
                new Beer {BeerID=7,Name = "OFS017", Family = "IPA", Type = "New England",Color="R", IBU = 7, ABV = 4}
            };
        }

        public IEnumerable<UserProfile> GetUserProfiles()
        {
            return new List<UserProfile>
            {
                new UserProfile
                {
                    User = new User
                    {
                         UserID=1,FirstName= "Akis",LastName = "Repanas",BirthDate = DateTime.Parse("1996-4-12"),Gender=Gender.Gay
                        ,Location = new Location{Address="Bathis 29",Country="Albania",PostalCode=14331 }
                        ,UserCredentials = new UserCredentials { EmailAdress = "hello@akis",UserName = "akisrep123",Password = "akis25"}
                    }
                },
                new UserProfile
                {
                    User = new User
                    {
                         UserID=2,FirstName= "Labros",LastName = "Mazis",BirthDate = DateTime.Parse("1992-3-11"),Gender=Gender.Trans
                        ,Location = new Location{Address="Baktrianis 12",Country="Turkey",PostalCode=13311 }
                        ,UserCredentials = new UserCredentials { EmailAdress = "hello@labros",UserName = "labrosmaz22",Password = "labrosftw31"}
                    }
                },
                new UserProfile
                {
                    User = new User
                    {
                         UserID=3,FirstName= "Kostas",LastName = "Xatzis",BirthDate = DateTime.Parse("1994-1-18"),Gender=Gender.Vegan
                        ,Location = new Location{Address="Wropou 23",Country="Serbia",PostalCode=12431 }
                        ,UserCredentials = new UserCredentials { EmailAdress = "hello@kostas",UserName = "kostasxatz19",Password = "kostas1234"}
                    }
                },
                new UserProfile
                {
                    User = new User
                    {
                         UserID=4,FirstName= "Peri",LastName = "Ahdino",BirthDate = DateTime.Parse("1990-3-3"),Gender=Gender.Pansexual
                        ,Location = new Location{Address="Oulof 33",Country="Greece",PostalCode=15331 }
                        ,UserCredentials = new UserCredentials { EmailAdress = "hello@peri",UserName = "periahdino40",Password = "noscaffolding24"}
                    }
                }
            };
        }

        public IEnumerable<AssignUserBeers> GetUserBeers()
        {
            return new List<AssignUserBeers>
            {
                new AssignUserBeers { UserID =1 ,BeerID =1},
                new AssignUserBeers { UserID =1 ,BeerID =2},
                new AssignUserBeers { UserID =1 ,BeerID =7},
                new AssignUserBeers { UserID =2 ,BeerID =3},
                new AssignUserBeers { UserID =2 ,BeerID =4},
                new AssignUserBeers { UserID =3 ,BeerID =5},
                new AssignUserBeers { UserID =3 ,BeerID =6},
                new AssignUserBeers { UserID =3 ,BeerID =7},
                new AssignUserBeers { UserID =4 ,BeerID =2},
                new AssignUserBeers { UserID =4 ,BeerID =1},
                new AssignUserBeers { UserID =4 ,BeerID =6},
            };
        }
    }
}