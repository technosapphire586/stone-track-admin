using Dapper;
using System;
using System.Threading.Tasks;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Models;

namespace StoneTrackAdmin.Services
{
    public class LoginService : ILogin
    {
        private readonly IDapper _dapper;
        public LoginService(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<GetLoginDataModel> AdminLogin(string UserName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                string query = string.Empty;
                query = "select AdminId,name,UserName,password from AdminLogin where " +
                    "UserName=@UserName and IsActive=1 and IsDelete=0";
                return await _dapper.GetFirstOrDefaultAsync<GetLoginDataModel>(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

