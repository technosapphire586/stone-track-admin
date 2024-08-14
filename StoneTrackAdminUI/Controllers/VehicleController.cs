using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using StoneTrackAdmin.Models;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using StoneTrackAdmin.Utlities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IBasicUtility _basic;
        private readonly IVehicle _vehical;
        private IExportUtility _exportUtility;
        private IPrintService _printService;
        private IConverter _converter;
        private IWebHostEnvironment hostingEnv;
        public VehicleController(IBasicUtility basic, IVehicle vehical, IExportUtility exportUtility, IPrintService printService, IConverter converter, 
            IWebHostEnvironment env)
        {
            _vehical = vehical;
            _basic = basic;
            _exportUtility = exportUtility;
            _printService = printService;
            _converter = converter;
            hostingEnv = env;
        }

        [HttpGet]
        public async Task<IActionResult> VehicleDetail()
        {
            var result = await _vehical.VehicleDetails();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVehicle(int ID)
        {
            await _vehical.DeleteVehicleDetails(ID);

            var response = new
            {
                status = true,
                Msg = "Vehicle Deleted",
                data = ""
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddVehicle(int ID = 0)
        {
            if (ID > 0)
            {
                var result = await _vehical.GetVehicleDetailsById(ID);
                return View(result);
            }
            else
            {
                VehicleModel obj = new VehicleModel();
                obj.ID = ID;
                return View(obj);
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleModel Viewmodel)
        {
            if (Viewmodel.ID > 0)
            {
                await _vehical.UpdateVehicle(Viewmodel);
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            else
            {
                await _vehical.InsertVehicle(Viewmodel);
                TempData["SuccessMessage"] = "Record Added Successfully";
            }

            return RedirectToAction("VehicleDetail", "Vehicle");
        }

        public async Task<IActionResult> ExportExcel()
        {
            
            IList<VehicleExportExcelModel> VehicleList = new List<VehicleExportExcelModel>();

            VehicleList = await _vehical.VehicleExcelData();

            IWorkbook workbook = _exportUtility.WriteExcelWithNPOI(VehicleList, "xlsx");
            string contentType = "";
            MemoryStream tempStream = null;
            MemoryStream stream = null;
            try
            {
                // 1. Write the workbook to a temporary stream
                tempStream = new MemoryStream();
                workbook.Write(tempStream);
                // 2. Convert the tempStream to byteArray and copy to another stream
                var byteArray = tempStream.ToArray();
                stream = new MemoryStream();
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Seek(0, SeekOrigin.Begin);
                // 3. Set file content type
                contentType = workbook.GetType() == typeof(XSSFWorkbook) ? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" : "application/vnd.ms-excel";
                // 4. Return file
                return File(
                    fileContents: stream.ToArray(),
                    contentType: contentType,
                    fileDownloadName: "Vehicle List" + DateTime.Now.ToString() + ((workbook.GetType() == typeof(XSSFWorkbook)) ? ".xlsx" : "xls"));
            }
            finally
            {
                if (tempStream != null) tempStream.Dispose();
                if (stream != null) stream.Dispose();
            }
        }

        //this method genrate html for save as button and genreate pdf document
        [HttpGet]
        public async Task<IActionResult> CreatePDF()
        {
            string HtmlContent = null;
            ViewBag.BaseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string fileName = DateTime.Now.ToString("ddMMyyyyssff") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 5 },
                DocumentTitle = "PDF Report",

            };

            IList<VehicleExportExcelModel> VehicleList = new List<VehicleExportExcelModel>();

            VehicleList = await _vehical.VehicleExcelData();
            HtmlContent = await _printService.RenderViewToStringAsync("/Views/PrintTemplate/VehicleTemplate.cshtml", VehicleList);

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //HtmlContent = await GeneratePOFormat(poid),
                HtmlContent = HtmlContent,
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "pdfCss.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = false },

            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            try
            {
                var file = _converter.Convert(pdf);
                byte[] bytes = file;


                FileStream fs = new FileStream(hostingEnv.WebRootPath + "/GenratedPfd/" + fileName.Replace('/', '_'), FileMode.OpenOrCreate);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                return File(file, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
