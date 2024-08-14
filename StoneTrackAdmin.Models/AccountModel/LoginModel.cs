using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class LoginModel
    {
		public int AdminId { get; set; }
		public string Name { get; set; }
		[Required(ErrorMessage = "User Name is required")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
		public string Token { get; set; }
		public string ConfirmPassword { get; set; }
		public bool IsActive { get; set; }
		public bool IsDelete { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
