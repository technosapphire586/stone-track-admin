
using Dapper;
using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
    {
        public class UserServices : IUser
        {

            private readonly IDapper _dapper;
            public UserServices(IDapper dapper)
            {
                _dapper = dapper;
            }
            public async Task<List<UserModel>> UserDetails()
            {
                try
                {
                    string query = string.Empty;
                    query = "SELECT UserId,Name,MobileNo,UserName,Password,UserType,EmailAddress,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate,IsActive, " +
                        " IsDeleted FROM UserTable where  IsActive=1 and IsDeleted=0 Order By UserId desc";
                    var data = await _dapper.GetAllAsync<UserModel>(query);
                    return data.ToList();
                }
                catch (Exception ex) { throw ex; }
            }

            public async Task<UserModel> GetUserDetailsById(int UserId)
            {
                try
                {
                    string query = string.Empty;
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", UserId);
                    query = "SELECT UserId,Name,MobileNo,UserName,Password,UserType,EmailAddress,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate,IsActive," +
                        "IsDeleted FROM UserTable where UserId = @UserId ";
                    var data = await _dapper.GetFirstOrDefaultAsync<UserModel>(query, parameters);
                    return data;
                }
                catch (Exception ex) { throw ex; }
            }

            public async Task DeleteUserDetails(int UserId)
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", UserId);
                    string query = string.Empty;
                    query = "update UserTable set IsActive=0 ,IsDeleted=1 where UserId=@UserId";
                    await _dapper.InsertDelete(query, parameters);
            }
                catch (Exception ex)
                {
                    throw ex;
                }
            }



            public async Task UpdateUser(UserModel data)
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", data.UserId);
                    parameters.Add("@Name", data.Name);
                    parameters.Add("@MobileNo", data.MobileNo);
                    parameters.Add("@UserName", data.UserName);
                    parameters.Add("@Password", data.Password);
                    parameters.Add("@EmailAddress", data.EmailAddress);
                    //parameters.Add("@ProfilePic", data.ProfilePic);
                    parameters.Add("@UserType", data.UserType);
                    string query = string.Empty;
                    query = $"Update UserTable set Name=@Name,MobileNo=@MobileNo,UserName=@UserName,UserType=@UserType,Password=@Password," +
                    $"EmailAddress=@EmailAddress,UpdatedDate=GETDATE() where UserId=@UserId";

                    await _dapper.InsertDelete(query, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task InsertUser(UserModel data)
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", data.UserId);
                    parameters.Add("@Name", data.Name);
                    parameters.Add("@MobileNo", data.MobileNo);
                    parameters.Add("@UserName", data.UserName);
                    parameters.Add("@Password", data.Password);
                    //parameters.Add("@ProfilePic", data.ProfilePic);
                    parameters.Add("@EmailAddress", data.EmailAddress);
                    parameters.Add("@UserType", data.UserType);
                    string query = string.Empty;
                    query = $"INSERT INTO UserTable (Name,MobileNo,UserName,Password,UserType,EmailAddress,CreatedBy,CreatedDate,IsActive,IsDeleted)" +
                        $" VALUES (@Name,@MobileNo,@UserName,@Password,@UserType,@EmailAddress,0,GETDATE(),1,0);";

                    await _dapper.InsertDelete(query, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public async Task<bool> CheckExistingUserName(string UserName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                string query = string.Empty;
                query = "Select count(UserId) from UserTable WHERE IsDeleted=0 and UserName=@UserName";
                int count = await _dapper.GetFirstOrDefaultAsync<int>(query, parameters);
                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
    }


