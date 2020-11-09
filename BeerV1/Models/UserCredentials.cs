using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerV1.Models
{
    public class UserCredentials
    {
		[Key]
		[ForeignKey("User")]
		public int UserID { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Username should be 3-20 characters long")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string EmailAdress { get; set; }

		[Required]
		[DataType(DataType.Password)]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public string Password { get; set; }


		public User User { get; set; }
	}
}