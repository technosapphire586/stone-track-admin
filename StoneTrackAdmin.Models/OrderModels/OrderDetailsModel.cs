using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel()
        {
            OrderDetailsList = new List<OrderDetailsModel>();
        }
        public int CountNewOrder { get; set; }
        public int CountVehicleInOrder { get; set; }
        public int CountDispatchedOrder { get; set; }
        public int CountLoadedOrder { get; set; }

        public List<OrderDetailsModel> OrderDetailsList { get; set; }

    }
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverMobileNo { get; set; }
        public string MaterialType { get; set; }
        public string GSTNO { get; set; }
        public float Weight { get; set; }
        public float Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public string EntrySlipImageUrl { get; set; }
        public string PaymentSlipUrl { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float ActualWeight { get; set; }
        public float NetAmount { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceImageUrl { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int CreatedBy { get; set; }
       
    }

    public class OrderDetailsCountModel
    {
        public int CountNewOrder { get; set; }
        public int CountVehicleInOrder { get; set; }
        public int CountDispatchedOrder { get; set; }
        public int CountLoadedOrder { get; set; }
    }
}
