using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public interface IVehicle
    {
        Task<List<VehicleModel>> VehicleDetails();
        Task<VehicleModel> GetVehicleDetailsById(int ID);
        Task DeleteVehicleDetails(int ID);
        Task UpdateVehicle(VehicleModel data);
        Task InsertVehicle(VehicleModel data);
        Task<List<VehicleExportExcelModel>> VehicleExcelData();
    }
}
