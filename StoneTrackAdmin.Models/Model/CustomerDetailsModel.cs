using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoneTrackAdmin.Models
{
	public class CustomerListModel
    {
		public string SearchKey { get; set; }

		public CustomerDetailsModel CustomerDetailsList { get; set; }
	}
    public class CustomerDetailsModel
    {
		public int CustomerId { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Mobile No is required")]
		[RegularExpression("([0-9]+)", ErrorMessage = "Please enter only Number")]
		[MaxLength(10,ErrorMessage = "Please enter 10 degit Mobile No"), MinLength(10,ErrorMessage = "Please enter 10 degit Mobile No"), ]
		public string MobileNo { get; set; }
		[EmailAddress]
		public string EmailAddress { get; set; }
		public string GSTNO { get; set; }
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDelete { get; set; }
	}
}
