using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerV1.Models
{
    public class User
    {
        public int UserID { get; set; }

		
		public Gender? Gender { get; set; }

		[Required]
		[StringLength(20,MinimumLength = 3,ErrorMessage ="Last Name should be 3-20 characters long")]
		public string LastName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "First Name should be 3-20 characters long")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name ="Address")]
		public int? LocationID { get; set; }
		public Location Location { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Birth Day")]
		[AdultMembers]
		public DateTime? BirthDate { get; set; }

		public string FullName  // calculated property
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

        public UserCredentials UserCredentials { get; set; }
		
		public UserProfile UserProfile { get; set; }
    }
}