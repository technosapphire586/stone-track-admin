using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class GetLoginDataModel
    {
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }
		public byte[] Password { get; set; }
		public bool IsActive { get; set; }
		public bool IsDelete { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
