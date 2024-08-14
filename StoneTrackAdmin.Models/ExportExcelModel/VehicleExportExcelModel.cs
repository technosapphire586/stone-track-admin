using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class VehicleExportExcelModel
    {
        public int ID { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverMobileNo { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobileNo { get; set; }
    }
}
