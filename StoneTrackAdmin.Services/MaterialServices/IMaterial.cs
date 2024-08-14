using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public interface IMaterial
    {
        Task<List<MaterialModel>> MaterialDetails();
        Task<MaterialModel> GetMaterialDetailsById(int MaterialID);
        Task DeleteMaterialDetails(int MaterialID);
        Task UpdateMaterial(MaterialModel data);
        Task InsertMaterial(MaterialModel data);
    }
}
