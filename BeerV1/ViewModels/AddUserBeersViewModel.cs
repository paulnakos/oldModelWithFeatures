using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerV1.ViewModels
{
    public class AddUserBeersViewModel
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public bool Chosen { get; set; }
    }
}