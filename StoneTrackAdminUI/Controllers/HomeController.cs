//using StoneTrackAdmin.Models;
//using StoneTrackAdmin.Services;
//using StoneTrackAdmin.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SelectPdf;
using System;
using System.Linq;
using StoneTrackAdmin.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Models;

namespace StoneTrackApi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomers _customer;
        private readonly IConfiguration configuration;
        //private readonly IFormDataServices _formDataServices;
        //private readonly IBasicUtility _basic;
        //private readonly IJsonResponseFromat _jsonResponseFromat;
        //private readonly IMailService _mailservice;
        public HomeController(ICustomers Customer, IConfiguration configuration)
        {
            _customer = Customer;
           this.configuration = configuration;
        //    _formDataServices = formDataServices;
        //    _mailservice = mailservice;
        //    _basic = basic;
        //    _jsonResponseFromat = JsonResponseFromat;
        }


        //public async Task<IActionResult> Index( string Status)
        //{
        //  var result = await _customer.DashboardOrderDetails(Status);
        //  return View(result);
        //}

        public async Task<IActionResult> Index(string Status = "New")
        {

            IList<OrderDetailsModel> OrderList = new List<OrderDetailsModel>();

            OrderList = await _customer.DashboardOrderDetails(Status);

            var Countresult = await _customer.CountOrder(); 

             OrderDetailsViewModel result = new OrderDetailsViewModel()
            {
                CountNewOrder = Countresult.CountNewOrder,
                CountVehicleInOrder = Countresult.CountVehicleInOrder,
                 CountLoadedOrder = Countresult.CountLoadedOrder,
                CountDispatchedOrder = Countresult.CountDispatchedOrder,
                OrderDetailsList = (List<OrderDetailsModel>)OrderList
            };
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Orders(string Status = null)
        {
            IList<OrderDetailsModel> OrderList = new List<OrderDetailsModel>();
            if(Status == null)
            {
                OrderList = await _customer.OrderDetails();
            }
            else
            {
                OrderList = await _customer.StatusOrderDetails(Status);
            }

            var Countresult = await _customer.CountTotaOrder();

            OrderDetailsViewModel result = new OrderDetailsViewModel()
            {
                CountNewOrder = Countresult.CountNewOrder,
                CountVehicleInOrder = Countresult.CountVehicleInOrder,
                CountLoadedOrder = Countresult.CountLoadedOrder,
                CountDispatchedOrder = Countresult.CountDispatchedOrder,
                OrderDetailsList = (List<OrderDetailsModel>)OrderList
            };
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrder(int OrderId)
        {
            var ImageUrl = configuration.GetSection("BaseUrl")["ApiUrl"];
            var result = await _customer.OrderDetailsByOrderId(OrderId);
            result.PaymentSlipUrl = $"{ImageUrl}/{result.PaymentSlipUrl}";
            result.EntrySlipImageUrl = $"{ImageUrl}/{result.EntrySlipImageUrl}";
            result.InvoiceImageUrl = $"{ImageUrl}/{result.InvoiceImageUrl}";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrders(int OrderId)
        {
            await _customer.DeleteOrdersDetails(OrderId);

            var response = new
            {
                status = true,
                Msg = "Material Deleted",
                data = ""
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GenerateInvoice(int OrderId)
        {
            var result = await _customer.GenerateInvoiceData(OrderId);
            return View(result);
        }


        //        [HttpGet]
        //        public async Task<IActionResult> CustomerView(int CustomerId)
        //        {
        //            var result = await _customer.ViewCustomerDetails(CustomerId);

        //            return View(result);
        //        }
        //        [HttpGet]
        //        public async Task<IActionResult> DeleteCustomer(int CustomerId)
        //        {
        //            await _customer.DeleteCustomerDetails(CustomerId);

        //            return RedirectToAction("CustomerDetail", "Home");
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> CustomerEdit(int CustomerId)
        //        {
        //            var result = await _customer.EditCustomerDetails(CustomerId);

        //            return View(result);
        //        }

        //        [HttpPost]
        //        public async Task<IActionResult> CustomerEdit(ViewCustomerDetailsModel Viewmodel)
        //        {
        //            await _customer.UpdateCustomer(Viewmodel);
        //            return RedirectToAction("CustomerDetail", "Home");
        //        }



        //        [HttpPost]
        //        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusModel Viewmodel)
        //        {
        //            try
        //            {
        //                await _customer.UpdateOrderStatus(Viewmodel);
        //                //GenrateEmailUploadDoucmentTamplet

        //                return Json("Status Updated");
        //            }
        //            catch (Exception ex)
        //            {
        //                return Json("Something went wrong", ex);
        //            }
        //        }

        //        [HttpPost]
        //        public async Task<IActionResult> UpdatePaymentStatus(UpdateOrderStatusModel Viewmodel)
        //        {
        //            try
        //            {
        //                var result1 = await _customer.GetEmailData(Viewmodel.OrderId);
        //                await _customer.UpdatePaymentStatus(Viewmodel,result1.TotalAmount);
        //                await _customer.AddInviceCount(Viewmodel.OrderId);
        //                var result = await _customer.GetEmailData(Viewmodel.OrderId);
        //                if (result != null)
        //                {
        //                    MailRequest sendmail = new MailRequest();
        //                    sendmail.ToEmail = result.EmailAddress;
        //                    sendmail.Subject = "New Order Placed for Legumize India Pvt Ltd.";
        //                    sendmail.Body = _basic.GenrateOrderEmailTamplet(result.OrderId, result.CustomerName, result.ServiceName, result.TotalAmount, result.OrderDate);
        //                    await _mailservice.SendEmailAsync(sendmail);
        //                }
        //                return Json("Status Updated");
        //            }
        //            catch (Exception ex)
        //            {
        //                return Json("Something went wrong", ex);
        //            }
        //        }

        //        [HttpPost]
        //        public async Task<IActionResult> UploadOrderDoucment([FromForm] UpdateOrderStatusModel Viewmodel)
        //        {
        //            try
        //            {
        //                Viewmodel.UpdateDoucmentUrl = Viewmodel.UpdateDoucment != null ? await _basic.UploadFile(Viewmodel.UpdateDoucment, "UploadDoucment") : null;

        //                await _customer.UploadDoucment(Viewmodel);

        //                var result = await _customer.GetEmailData(Viewmodel.OrderId);
        //                if (result != null)
        //                {
        //                    MailRequest sendmail = new MailRequest();
        //                    sendmail.ToEmail = result.EmailAddress;
        //                    sendmail.Subject = "Legumize India-Your document (" + result.ServiceName + ") is ready for review.";
        //                    sendmail.Body = _basic.GenrateEmailUploadDoucmentTamplet(result.CustomerName, result.ServiceName);
        //                    await _mailservice.SendEmailAsync(sendmail);
        //                }

        //                return Json("Doucment Upload");
        //            }
        //            catch (Exception ex)
        //            {
        //                return Json("Something went wrong", ex);
        //            }
        //        }

        //        [HttpGet]
        //        public async Task<JsonResult> GetStateByCustomerID(int CustomerId)
        //        {
        //            var state = await _customer.GetStateByCustomerId(CustomerId);
        //            return Json(state);
        //        }




        //        [HttpGet]
        //        public async Task<IActionResult> ViewOrders(int OrderId)
        //        {
        //            var result1 = await _formDataServices.PhotoFormAvailablety(OrderId);
        //            var result2 = await _formDataServices.ViewOrderDetailsFormData(OrderId);
        //            TempData["OrderId"] = OrderId;
        //            var ImageUrl1 = configuration.GetSection("BaseUrl")["ClientUrl"];

        //            if (result1 == "Filled With Photo")
        //            {
        //                result2.PhotoFormRequestM = await _formDataServices.PhotoFormRequestData(OrderId);
        //                result2.PhotoFormRequestM.PhotoOfyourDate = $"{ImageUrl1}/{result2.PhotoFormRequestM.PhotoOfyourDate}";
        //                result2.PhotoFormRequestM.PhotoOfYourData1 = $"{ImageUrl1}/{result2.PhotoFormRequestM.PhotoOfYourData1}";
        //                result2.PhotoFormRequestM.PhotoOfYourData2 = $"{ImageUrl1}/{result2.PhotoFormRequestM.PhotoOfYourData2}";
        //                result2.PhotoFormRequestM.DoucmentVerification = $"{ImageUrl1}/{result2.PhotoFormRequestM.DoucmentVerification}";
        //                result2.PhotoFormRequestM.DoucmentVerification1 = $"{ImageUrl1}/{result2.PhotoFormRequestM.DoucmentVerification1}";
        //                result2.PhotoFormRequestM.DoucmentVerification2 = $"{ImageUrl1}/{result2.PhotoFormRequestM.DoucmentVerification2}";
        //            }

        //            else
        //            {

        //                var result = await _formDataServices.ViewOrderDetails(OrderId);
        //                var ImageUrl = configuration.GetSection("BaseUrl")["ClientUrl"];
        //                if (result.ServiceId == 1)
        //                {
        //                    result.AffidavitMarriageDevorce = await _formDataServices.GetAffidavitMarriageOrDivorceManuallyById(result.RequestId);
        //                    result.AffidavitMarriageDevorce.YourDoucmentUrl = $"{ImageUrl}/{result.AffidavitMarriageDevorce.YourDoucmentUrl}";
        //                    result.AffidavitMarriageDevorce.SpouseDoucmentUrl = $"{ImageUrl}/{result.AffidavitMarriageDevorce.SpouseDoucmentUrl}";
        //                    result.AffidavitMarriageDevorce.DoucmentWhitnessFirstUrl = $"{ImageUrl}/{result.AffidavitMarriageDevorce.DoucmentWhitnessFirstUrl}";
        //                    result.AffidavitMarriageDevorce.DoucmentWhitnessSecondUrl = $"{ImageUrl}/{result.AffidavitMarriageDevorce.DoucmentWhitnessSecondUrl}";
        //                    result.AffidavitMarriageDevorce.OrderId = OrderId;
        //                    var accordanceOptions = new List<SelectListItem>
        //                    {
        //                        new SelectListItem { Value = "", Text = "--Select specify the applicable law--" },
        //                        new SelectListItem { Value = "Hindu Marriage Act", Text = "Hindu Marriage Act" },
        //                        new SelectListItem { Value = "Muslim Personal Law", Text = "Muslim Personal Law" },
        //                        new SelectListItem { Value = "Christian Marriage Act", Text = "Christian Marriage Act" },
        //                        new SelectListItem { Value = "Special Marriage Act", Text = "Special Marriage Act" }
        //                    };

        //                    ViewBag.AccordanceOptions = accordanceOptions
        //                        .Select(option => new SelectListItem
        //                        {
        //                            Value = option.Value,
        //                            Text = option.Text
        //                        })
        //                        .ToList();

        //                }
        //                else if (result.ServiceId == 2)
        //                {
        //                    result.StandardAffidavit = await _formDataServices.GetStandardAffidavitDataById(result.RequestId);
        //                    result.StandardAffidavit.Doucment = $"{ImageUrl}/{result.StandardAffidavit.Doucment}";
        //                    result.StandardAffidavit.OrderId = OrderId;

        //                }

        //                else if (result.ServiceId == 5)
        //                {
        //                    result.CasteCertificate = await _formDataServices.GetCasteCertificateDataById(result.RequestId);
        //                    result.CasteCertificate.Doucment = $"{ImageUrl}/{result.CasteCertificate.Doucment}";
        //                    result.CasteCertificate.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 6)
        //                {
        //                    result.BirthCertificate = await _formDataServices.GetBirthCertificateDataById(result.RequestId);
        //                    result.BirthCertificate.Doucment = $"{ImageUrl}/{result.BirthCertificate.Doucment}";
        //                    result.BirthCertificate.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 7)
        //                {
        //                    result.MarriageCertificate = await _formDataServices.GetMarriageCertificateById(result.RequestId);
        //                    result.MarriageCertificate.DocumentGroom = $"{ImageUrl}/{result.MarriageCertificate.DocumentGroom}";
        //                    result.MarriageCertificate.DocumentBride = $"{ImageUrl}/{result.MarriageCertificate.DocumentBride}";
        //                    result.MarriageCertificate.DocumentWithness1 = $"{ImageUrl}/{result.MarriageCertificate.DocumentWithness1}";
        //                    result.MarriageCertificate.DocumentWithness2 = $"{ImageUrl}/{result.MarriageCertificate.DocumentWithness2}";
        //                    result.MarriageCertificate.PhotoMarriedCouple = $"{ImageUrl}/{result.MarriageCertificate.PhotoMarriedCouple}";
        //                    result.MarriageCertificate.PicturesMarriage = $"{ImageUrl}/{result.MarriageCertificate.PicturesMarriage}";
        //                    result.MarriageCertificate.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 8)
        //                {
        //                    result.GiftCertificate = await _formDataServices.GetGiftCertificateById(result.RequestId);
        //                    result.GiftCertificate.DoucmentGiver = $"{ImageUrl}/{result.GiftCertificate.DoucmentGiver}";
        //                    result.GiftCertificate.DoucmentReceiver = $"{ImageUrl}/{result.GiftCertificate.DoucmentReceiver}";
        //                    result.GiftCertificate.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 9)
        //                {
        //                    result.SettlementAgreement = await _formDataServices.GetSettlementAgreementById(result.RequestId);
        //                    result.SettlementAgreement.DoucmentFirstPartyUrl = $"{ImageUrl}/{result.SettlementAgreement.DoucmentFirstPartyUrl}";
        //                    result.SettlementAgreement.DoucmentSecondPartyUrl = $"{ImageUrl}/{result.SettlementAgreement.DoucmentSecondPartyUrl}";
        //                    result.SettlementAgreement.DoucmentWhitnessFirstPartyUrl = $"{ImageUrl}/{result.SettlementAgreement.DoucmentWhitnessFirstPartyUrl}";
        //                    result.SettlementAgreement.DoucmentWhitnessSecondPartyUrl = $"{ImageUrl}/{result.SettlementAgreement.DoucmentWhitnessSecondPartyUrl}";
        //                    result.SettlementAgreement.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 10)
        //                {
        //                    result.PowerOfAttonary = await _formDataServices.GetPowerOfAttonaryById(result.RequestId);
        //                    result.PowerOfAttonary.DoucmentFirstPartyUrl1 = $"{ImageUrl}/{result.PowerOfAttonary.DoucmentFirstPartyUrl1}";
        //                    result.PowerOfAttonary.DoucmentFirstPartyUrl2 = $"{ImageUrl}/{result.PowerOfAttonary.DoucmentFirstPartyUrl2}";
        //                    result.PowerOfAttonary.DoucmentAttonaryUrl1 = $"{ImageUrl}/{result.PowerOfAttonary.DoucmentAttonaryUrl1}";
        //                    result.PowerOfAttonary.DoucmentAttonaryUrl2 = $"{ImageUrl}/{result.PowerOfAttonary.DoucmentAttonaryUrl2}";
        //                    result.PowerOfAttonary.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 12)
        //                {
        //                    result.SalesPurchaseAgreement = await _formDataServices.GetSalesPurchaseAgreementById(result.RequestId);
        //                    result.SalesPurchaseAgreement.SellerDoucmentUrl = $"{ImageUrl}/{result.SalesPurchaseAgreement.SellerDoucmentUrl}";
        //                    result.SalesPurchaseAgreement.BuyerDoucmentUrl = $"{ImageUrl}/{result.SalesPurchaseAgreement.BuyerDoucmentUrl}";
        //                    result.SalesPurchaseAgreement.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 13)
        //                {
        //                    result.NonDisclosureAgreement = await _formDataServices.GetNonDisclosureAgreementById(result.RequestId);
        //                    result.NonDisclosureAgreement.DoucmentRecipientUrl = $"{ImageUrl}/{result.NonDisclosureAgreement.DoucmentRecipientUrl}";
        //                    result.NonDisclosureAgreement.DoucmentCompanyUrl = $"{ImageUrl}/{result.NonDisclosureAgreement.DoucmentCompanyUrl}";
        //                    result.NonDisclosureAgreement.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 14)
        //                {
        //                    result.ServiceAgreement = await _formDataServices.GetServiceAgreementById(result.RequestId);
        //                    result.ServiceAgreement.ProviderDoucmentUrl = $"{ImageUrl}/{result.ServiceAgreement.ProviderDoucmentUrl}";
        //                    result.ServiceAgreement.ClientDoucmentUrl = $"{ImageUrl}/{result.ServiceAgreement.ClientDoucmentUrl}";
        //                    result.ServiceAgreement.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 15)
        //                {
        //                    result.PoliceVerification = await _formDataServices.GetPloiceVerificationById(result.RequestId);
        //                    result.PoliceVerification.AadharFrontImage = $"{ImageUrl}/{result.PoliceVerification.AadharFrontImage}";
        //                    result.PoliceVerification.AadharBackImage = $"{ImageUrl}/{result.PoliceVerification.AadharBackImage}";
        //                    result.PoliceVerification.PanCardImage = $"{ImageUrl}/{result.PoliceVerification.PanCardImage}";
        //                    result.PoliceVerification.OrderId = OrderId;
        //                }
        //                else if (result.ServiceId == 16)
        //                {
        //                    result.AffidavitForChangeofName = await _formDataServices.GetAffidavitForNameChangeById(result.RequestId);
        //                    result.AffidavitForChangeofName.Doucment = $"{ImageUrl}/{result.AffidavitForChangeofName.Doucment}";
        //                    result.AffidavitForChangeofName.OrderId = OrderId;
        //                }

        //                else if (result.ServiceId == 18)
        //                {
        //                    result.LastWill = await _formDataServices.GetLastWillById(result.RequestId);
        //                    result.LastWill.DoucmentFirstUrl = $"{ImageUrl}/{result.LastWill.DoucmentFirstUrl}";
        //                    result.LastWill.DoucmentSecondUrl = $"{ImageUrl}/{result.LastWill.DoucmentSecondUrl}";
        //                    result.LastWill.DoucmentWitnessFirstUrl = $"{ImageUrl}/{result.LastWill.DoucmentWitnessFirstUrl}";
        //                    result.LastWill.DoucmentWitnessSecondUrl = $"{ImageUrl}/{result.LastWill.DoucmentWitnessSecondUrl}";
        //                    result.LastWill.OrderId = OrderId;
        //                }

        //                else
        //                {
        //                    result.RentAgreement = await _formDataServices.GetRentAgreementById(result.RequestId);
        //                    result.RentAgreement.OwnerDoucment1 = $"{ImageUrl}/{result.RentAgreement.OwnerDoucment1}";
        //                    result.RentAgreement.OwnerDoucment2 = $"{ImageUrl}/{result.RentAgreement.OwnerDoucment2}";
        //                    result.RentAgreement.TenentDoucment1 = $"{ImageUrl}/{result.RentAgreement.TenentDoucment1}";
        //                    result.RentAgreement.TenentDoucment2 = $"{ImageUrl}/{result.RentAgreement.TenentDoucment2}";
        //                    result.RentAgreement.OrderId = OrderId;
        //                }
        //                return View(result);
        //            }

        //            return View(result2);
        //        }
        //        [HttpGet]
        //        public async Task<IActionResult> DeleteOrders(int OrderId)
        //        {
        //            await _customer.DeleteOrderDetails(OrderId);

        //            return RedirectToAction("Orders", "Home");
        //        }


        //        public FileResult GeneratePdf(string html)
        //        {
        //            html = html.Replace("strtTag", "<").Replace("EndTag", ">");
        //            HtmlToPdf objhtml = new HtmlToPdf();
        //            PdfDocument objdoc = objhtml.ConvertHtmlString(html);
        //            byte[] pdf = objdoc.Save();
        //            objdoc.Close();
        //            return File(pdf, "appli");
        //        }


        //        public async Task<IActionResult> AdminDashboardMonthlyBasisSale()
        //        {
        //            var sale = await _customer.AdminDashboardMonthlyBasisSale();

        //            var chartData = new MonthBasisSaleChartdata
        //            {
        //                Data = sale.Select(a => a.TotalSale).ToArray(),
        //                Labels = sale.Select(a => a.Month).ToArray(),
        //            };
        //            return Json(chartData);
        //        }


        //        public async Task<IActionResult> TotalNoOfCustomerMonthBasis()
        //        {

        //            GetMonthlySale TotalCustomerMonthBasis = new GetMonthlySale();
        //            var result = await _customer.TotalNoOfCustomerMonthBasis();
        //            var chartData = new TotalNoOfCustomerMonthBasisChartdata
        //            {
        //                Data = result.Select(a => a.TotalCustomer).ToArray(),
        //                Labels = result.Select(a => a.Month).ToArray(),
        //            };
        //            return Json(chartData);
        //        }

        //        public async Task<IActionResult> TopSellingServices()
        //        {
        //            try
        //            {
        //                var result = await _customer.TopSellingServicesCount();

        //                var chartData = new ApexChartData
        //                {
        //                    Data = result.Select(a => a.TotalTopSaleServices).ToArray(),
        //                    Labels = result.Select(a => a.ServiceName).ToArray(),
        //                };

        //                return Ok(_jsonResponseFromat.JsonMessage(true, "Month basis Vendor", chartData));
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }


        //        public async Task<IActionResult> RentAgreementPDF(int RentAgreementId)
        //        {
        //            try
        //            {
        //                var result=await _formDataServices.GetRentAgreementById(RentAgreementId);

        //                return View(result);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        //        public async Task<IActionResult> CustomerDashboardMonthlyBasisSale(int CustomerId)
        //        {
        //            var sale = await _customer.CustomerMonthlyBasisSale(CustomerId);

        //            var chartData = new MonthBasisSaleChartdata
        //            {
        //                Data = sale.Select(a => a.TotalSale).ToArray(),
        //                Labels = sale.Select(a => a.Month).ToArray(),
        //            };
        //            return Json(chartData);
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> CompleteOrdersDetails()
        //        {
        //            var result = await _customer.CompliteOrderDetails();
        //            return View(result);
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> PendingOrdersDetails()
        //        {
        //            var result = await _customer.PendingOrderDetails();
        //            return View(result);
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> PendingServicesName()
        //        {
        //            var result = await _customer.PendingServicesName();
        //            return Json(result);
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> UserLog()
        //        {
        //            var result = await _customer.CustomerDetails();

        //            return View(result);
        //        }

        //        public async Task<IActionResult> ActivityLog()
        //        {
        //            var result = await _customer.ActivityLogData();

        //            return View(result);
        //        }



        //        [HttpGet]
        //        public async Task<ActionResult> GenerateInvice(int OrderId)
        //        {
        //            var invicedata = await _customer.GetInviceData(OrderId);
        //            return View(invicedata);
        //        }

        //        [HttpPost]
        //        public async Task<IActionResult> CasteCertificateForm([FromForm] CasteCertificateModel ViewModel)
        //        {
        //            try
        //            {
        //                var insert = 0;
        //                //ViewModel.UplodeDoucmentUrl1 = ViewModel.UplodeDoucment1 != null ? await _basic.UploadFile(ViewModel.UplodeDoucment1, "CertificateDoucment") : null;
        //                //ViewModel.UplodeDoucmentUrl2 = ViewModel.UplodeDoucment2 != null ? await _basic.UploadFile(ViewModel.UplodeDoucment2, "CertificateDoucment") : null;
        //                //ViewModel.UplodeDoucmentUrl3 = ViewModel.UplodeDoucment3 != null ? await _basic.UploadFile(ViewModel.UplodeDoucment3, "CertificateDoucment") : null;
        //                //ViewModel.UplodeImageUrl1 = ViewModel.UplodeImage1 != null ? await _basic.UploadFile(ViewModel.UplodeImage1, "CertificateDoucment") : null;
        //                //ViewModel.UplodeImageUrl2 = ViewModel.UplodeImage2 != null ? await _basic.UploadFile(ViewModel.UplodeImage2, "CertificateDoucment") : null;
        //                //ViewModel.UplodeImageUrl3 = ViewModel.UplodeImage3 != null ? await _basic.UploadFile(ViewModel.UplodeImage3, "CertificateDoucment") : null;
        //                //insert = await _certificate.CreateLastWillAndTestamentWithPhoto(ViewModel, User.Identity.GetUserId());
        //                TempData["OrderId"] = insert;
        //                TempData["SuccessMessage"] = "Form Submitted Successfully";
        //                return RedirectToAction("DeliveryAddress1", "Customer", new { OrderId = insert });
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }
    }
}
