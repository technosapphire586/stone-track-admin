
using Dapper;
using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public class MaterialServices : IMaterial
    {

        private readonly IDapper _dapper;
        public MaterialServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<MaterialModel>> MaterialDetails()
        {
            try
            {
                string query = string.Empty;
                query = "SELECT MaterialID,MaterialName,PurchasePrice,SellingPrice, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    " IsDeleted FROM Material where  IsActive=1 and IsDeleted=0 Order By MaterialID desc";
                var data = await _dapper.GetAllAsync<MaterialModel>(query);
                return data.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<MaterialModel> GetMaterialDetailsById(int MaterialID)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@MaterialID", MaterialID);
                query = "SELECT MaterialID,MaterialName,PurchasePrice,SellingPrice, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    "IsDeleted FROM Material where MaterialID = @MaterialID ";
                var data = await _dapper.GetFirstOrDefaultAsync<MaterialModel>(query, parameters);
                return data;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteMaterialDetails(int MaterialID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaterialID", MaterialID);
                string query = string.Empty;
                query = "update Material set IsActive=0 ,IsDeleted=1 where MaterialID=@MaterialID";
                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task UpdateMaterial(MaterialModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaterialID", data.MaterialID);
                parameters.Add("@MaterialName", data.MaterialName);
                parameters.Add("@PurchasePrice", data.PurchasePrice);
                parameters.Add("@SellingPrice", data.SellingPrice);
                string query = string.Empty;
                query = $"Update Material set MaterialName=@MaterialName,PurchasePrice=@PurchasePrice,SellingPrice=@SellingPrice,UpdatedDate=GETDATE() where MaterialID=@MaterialID";

                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertMaterial(MaterialModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaterialID", data.MaterialID);
                parameters.Add("@MaterialName", data.MaterialName);
                parameters.Add("@PurchasePrice", data.PurchasePrice);
                parameters.Add("@SellingPrice", data.SellingPrice);
                string query = string.Empty;
                query = $"INSERT INTO Material (MaterialName,PurchasePrice,SellingPrice, CreatedBy,CreatedDate,IsActive, IsDeleted)" +
                    $" VALUES (@MaterialName,@PurchasePrice,@SellingPrice,0,GETDATE(),1, 0);";

                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

