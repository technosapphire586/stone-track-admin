using StoneTrackAdmin.Models;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using LegumizeUI.Utilites;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogin _login;
        private CryptoUtility cryptoUtility;

        // public ClaimsIdentity Subject { get; private set; }

        public AccountController(ILogin login)
        {
            _login = login;

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginModel model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {

                    if (cryptoUtility == null)
                        cryptoUtility = new CryptoUtility();

                    try
                    {
                        var result = await _login.AdminLogin(model.UserName);

                        if (result != null)
                        {
                            string pwd = cryptoUtility.Decrypt(result.Password);

                            if (result.Password != null && model.Password.Equals(cryptoUtility.Decrypt(result.Password)))
                            {
                                TempData["CustomerId"] = result.CustomerId;
                                TempData["CustomerName"] = result.Name ;
                               
                                List<Claim> claims = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier, model.UserName),
                                new Claim("UserName", result.UserName.ToString()),
                                new Claim("UserID", result.CustomerId.ToString()),
                                new Claim("OtherProperties","Example Role")
                            };
                                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                                    CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties properties = new AuthenticationProperties()
                                {
                                    AllowRefresh = true,
                                    IsPersistent = model.Equals("false")
                                };
                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["InvalidPassword"] = "Invalid Password";
                            }
                        }
                        else
                        {
                            ViewData["InvalidEmail"] = "Email address not found";
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //}
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            TempData.Remove("CustomerId");
            //  HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }
    }
}
