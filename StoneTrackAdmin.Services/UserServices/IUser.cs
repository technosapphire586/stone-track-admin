using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public interface IUser
    {
        Task<List<UserModel>> UserDetails();
        Task<UserModel> GetUserDetailsById(int UserId);
        Task DeleteUserDetails(int UserId);
        Task UpdateUser(UserModel data);
        Task InsertUser(UserModel data);
        Task<bool> CheckExistingUserName(string UserName);
    }
}
