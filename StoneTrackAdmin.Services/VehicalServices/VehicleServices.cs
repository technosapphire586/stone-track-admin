using Dapper;
using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
   public class VehicleServices: IVehicle
    {

        private readonly IDapper _dapper;
        public VehicleServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<VehicleModel>> VehicleDetails()
        {
            try
            {
                string query = string.Empty;
                query = "SELECT ID,VehicleNo,DriverName,DriverMobileNo,OwnerName,OwnerMobileNo, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    " IsDeleted FROM Vehicle where  IsActive=1 and IsDeleted=0 Order By ID desc";
                var data = await _dapper.GetAllAsync<VehicleModel>(query);
                return data.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<List<VehicleExportExcelModel>> VehicleExcelData()
        {
            try
            {
                string query = string.Empty;
                query = "SELECT ID,VehicleNo,DriverName,DriverMobileNo,OwnerName,OwnerMobileNo, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    " IsDeleted FROM Vehicle where  IsActive=1 and IsDeleted=0";
                var data = await _dapper.GetAllAsync<VehicleExportExcelModel>(query);
                return data.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<VehicleModel> GetVehicleDetailsById(int ID)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                query = "SELECT ID,VehicleNo,DriverName,DriverMobileNo,OwnerName,OwnerMobileNo, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    "IsDeleted FROM Vehicle where ID = @ID ";
                var data = await _dapper.GetFirstOrDefaultAsync<VehicleModel>(query, parameters);
                return data;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteVehicleDetails(int ID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                string query = string.Empty;
                query = "update Vehicle set IsActive=0 ,IsDeleted=1 where ID=@ID";
                await _dapper.InsertDelete(query, parameters);
                //await _dapper.GetFirstOrDefaultAsync<ViewCustomerDetailsModel>(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task UpdateVehicle(VehicleModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", data.ID);
                parameters.Add("@VehicleNo", data.VehicleNo);
                parameters.Add("@DriverName", data.DriverName);
                parameters.Add("@DriverMobileNo", data.DriverMobileNo);
                parameters.Add("@OwnerName", data.OwnerName);
                parameters.Add("@OwnerMobileNo", data.OwnerMobileNo);
                string query = string.Empty;
                query = $"Update Vehicle set VehicleNo=@VehicleNo,DriverName=@DriverName,DriverMobileNo=@DriverMobileNo,OwnerName=@OwnerName," +
                    $"OwnerMobileNo=@OwnerMobileNo,UpdatedDate=GETDATE() where ID=@ID";

                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertVehicle(VehicleModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", data.ID);
                parameters.Add("@VehicleNo", data.VehicleNo);
                parameters.Add("@DriverName", data.DriverName);
                parameters.Add("@DriverMobileNo", data.DriverMobileNo);
                parameters.Add("@OwnerName", data.OwnerName);
                parameters.Add("@OwnerMobileNo", data.OwnerMobileNo);
                string query = string.Empty;
                query = $"INSERT INTO Vehicle (VehicleNo,DriverName,DriverMobileNo,OwnerName,OwnerMobileNo, CreatedBy,CreatedDate,IsActive, IsDeleted)" +
                    $" VALUES (@VehicleNo,@DriverName,@DriverMobileNo,@OwnerName,@OwnerMobileNo, 0,GETDATE(),1, 0);";

                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
