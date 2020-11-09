using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BeerV1.Models;

namespace BeerV1.Dtos
{
    public class UserDto
    {
		public int UserID { get; set; }


		public Gender? Gender { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name should be 3-20 characters long")]
		public string LastName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "First Name should be 3-20 characters long")]
		public string FirstName { get; set; }

		[Required]
		public int? LocationID { get; set; }
		

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? BirthDate { get; set; }

	
	}
}