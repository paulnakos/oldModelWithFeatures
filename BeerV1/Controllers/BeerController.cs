using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerV1.MockRepositories;
using BeerV1.Models;

namespace BeerV1.Controllers
{
    public class BeerController : Controller
    {
        private readonly MockRepository mockBeerRepository = new MockRepository();
        private IEnumerable<Beer> selectedBeers = new List<Beer>();

        // GET: Beer Choices
        public ActionResult Index()
        {
            return View();
        } 
        
        public ActionResult AllBeers()
        {
            var beers = mockBeerRepository.CreateBeerList();
            return View(beers);
        } 

        public ActionResult YellowBeers()
        {
            selectedBeers = GetBeerByColor("Y");
            return View(selectedBeers);
        }

        public ActionResult RedBeers()
        {
            selectedBeers = GetBeerByColor("R");
            return View(selectedBeers);
        }

        public ActionResult DarkBeers()
        {
            selectedBeers = GetBeerByColor("B");
            return View(selectedBeers);
        }

        private IEnumerable<Beer> GetBeerByColor(string color) 
        {
            var beers = mockBeerRepository.CreateBeerList();

            var selectedBeers = from b in beers
                                where b.Color == color
                                select b;

            return selectedBeers;

        } //  private IEnumerable<Beer> GetBeerByColor(string color) end //

    } //  public class BeerController : Controller end //

} // namespace end //