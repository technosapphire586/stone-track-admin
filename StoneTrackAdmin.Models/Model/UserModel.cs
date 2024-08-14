using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile No is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter only Number")]
        [MaxLength(10, ErrorMessage = "Please enter 10 degit Mobile No"), MinLength(10, ErrorMessage = "Please enter 10 degit Mobile No"),]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(12, ErrorMessage = "Password is maximum 12 degit"), MinLength(8, ErrorMessage = "Password is minimum 8 degit"),]
        public string PasswordView { get; set; }
        //public string ProfilePic { get; set; }
        //public IFormFile ProfilePicData { get; set; }
        //public IFormFile Url { get; set; }
        [Required(ErrorMessage = "User Type is required")]
        public string UserType { get; set; }
    }
}
