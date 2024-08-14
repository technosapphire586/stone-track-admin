using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoneTrackAdmin.Models
{
   public class VehicleModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Vehicle No is required")]
        public string VehicleNo { get; set; }
        [Required(ErrorMessage = "Driver Name is required")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Driver Mobile No is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter only Number")]
        [MaxLength(10, ErrorMessage = "Please enter 10 degit Mobile No"), MinLength(10, ErrorMessage = "Please enter 10 degit Mobile No"),]
        public string DriverMobileNo { get; set; }
        public string OwnerName { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter only Number")]
        [MaxLength(10, ErrorMessage = "Please enter 10 degit Mobile No"), MinLength(10, ErrorMessage = "Please enter 10 degit Mobile No"),]
        public string OwnerMobileNo { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
