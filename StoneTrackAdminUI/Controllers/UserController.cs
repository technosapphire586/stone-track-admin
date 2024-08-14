using LegumizeUI.Utilites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StoneTrackAdmin.Models;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly IBasicUtility _basic;
        private readonly IUser _user;
        private CryptoUtility cryptoUtility;
        private readonly IConfiguration configuration;
        public UserController(IBasicUtility basic, IUser user, IConfiguration configuration)
        {
            this.configuration = configuration;
            _user = user;
            _basic = basic;
        }

        [HttpGet]
        public async Task<IActionResult> UserDetail()
        {
            var ImageUrl = configuration.GetSection("BaseUrl")["ClientUrl"];
            var result = await _user.UserDetails();
            if (cryptoUtility == null)
                cryptoUtility = new CryptoUtility();
            foreach (var user in result)
            {
                user.PasswordView= cryptoUtility.Decrypt(user.Password);
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            await _user.DeleteUserDetails(UserId);
            var response = new
            {
                status = true,
                Msg = "User Deleted",
                data = ""
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser(int UserId = 0)
        {
            if (UserId > 0)
            {
                var result = await _user.GetUserDetailsById(UserId);
                if (cryptoUtility == null)
                    cryptoUtility = new CryptoUtility();

                result.PasswordView = cryptoUtility.Decrypt(result.Password);
                return View(result);
            }
            else
            {
                UserModel obj = new UserModel();
                obj.UserId = UserId;
                return View(obj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm]UserModel Viewmodel)
        {
            if (cryptoUtility == null)
                cryptoUtility = new CryptoUtility();
            Viewmodel.Password = cryptoUtility.Encrypt(Viewmodel.PasswordView);

            if (Viewmodel.UserId > 0)
            {
                await _user.UpdateUser(Viewmodel);
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            else
            {
                var chk = await _user.CheckExistingUserName(Viewmodel.UserName);
                if (chk == true)
                {
                   // Viewmodel.ProfilePic = Viewmodel.ProfilePicData != null ? await _basic.UploadFile(Viewmodel.ProfilePicData, "ProfilePic") : null;
               
                    await _user.InsertUser(Viewmodel);
                    TempData["SuccessMessage"] = "Record Added Successfully";
                }
                else
                {
                    TempData["ExistingUserName"] = "This User Name Already Exists";
                    
                    return View(Viewmodel);
                }
            }
            return RedirectToAction("UserDetail", "User");
        }

    }
}
