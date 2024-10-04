using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class InvoiceModel
    {
        public int OrderId { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverMobileNo { get; set; }
        public string MaterialType { get; set; }
        public float Weight { get; set; }
        public float Amount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float ActualWeight { get; set; }
        public float NetAmount { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string GSTNO { get; set; }
        public float ActualAmount { get; set; }
        public float GSTAmount { get; set; }
        public float WeightPer { get; set; }
       
    }

    public class DownloadEntrySlipModel
    {
        public int OrderId { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverMobileNo { get; set; }
        public string MaterialType { get; set; }
        public float Amount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PaymentStatus { get; set; }
        public float ActualWeight { get; set; }
        public float NetAmount { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
