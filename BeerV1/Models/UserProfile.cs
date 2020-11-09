using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerV1.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        public ICollection<Beer>  Beers { get; set; }

    }
}