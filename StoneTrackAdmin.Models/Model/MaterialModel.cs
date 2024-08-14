using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class MaterialModel
    {
        public int MaterialID { get; set; }
        [Required(ErrorMessage = "Material Name is required")]
        public string MaterialName { get; set; }
        public float PurchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
