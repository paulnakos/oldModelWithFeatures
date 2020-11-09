using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerV1.Models
{
	public class Beer
	{
        public int BeerID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int IBU { get; set; }
        public double ABV { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }

    } 

} 