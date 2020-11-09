using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerV1.Models;

namespace BeerV1.ViewModels
{
    public class AssignUserBeers
    {
        public int UserID { get; set; }
        public int BeerID { get; set; }
    }
}