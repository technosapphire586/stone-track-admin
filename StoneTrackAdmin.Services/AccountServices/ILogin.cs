using StoneTrackAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public interface ILogin
    {
        Task<GetLoginDataModel> AdminLogin(string EmailAddress);
    }
}
