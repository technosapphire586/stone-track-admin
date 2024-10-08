using StoneTrackAdmin.Models;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using LegumizeUI.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoneTrackApi.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        private readonly IBasicUtility _basic;
        private readonly ICustomers _customer;
        public CustomerController( IBasicUtility basic,ICustomers customer)
        {
            _customer = customer;
            _basic = basic;
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetail()
        {
            var result = await _customer.CustomerDetails();

            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int CustomerId)
        {
            await _customer.DeleteCustomerDetails(CustomerId);
            var response = new
            {
                status = true,
                Msg = "Customer Deleted",
                data = ""
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer(int CustomerId=0)
        {
            if (CustomerId > 0)
            {
                var result = await _customer.GetCustomerDetailsById(CustomerId);
                return View(result);
            }
            else
            {
                CustomerDetailsModel obj = new CustomerDetailsModel();
                obj.CustomerId = CustomerId;
                return View(obj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDetailsModel Viewmodel)
        {
            if(Viewmodel.CustomerId > 0)
            {
                await _customer.UpdateCustomer(Viewmodel);
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            else
            {
                await _customer.InsertCustomer(Viewmodel);
                TempData["SuccessMessage"] = "Record Added Successfully";
            }
           
            return RedirectToAction("CustomerDetail", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> GenerateEntrySlip(int OrderId)
        {
            try
            {
                var result = await _customer.DownloadEntrySlip(OrderId);
                if (result!=null)
                {
                    return View(result);
                }
                else
                {
                    ViewBag.Error = "Record not Found !!";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View();
            }
        }

    }
}
