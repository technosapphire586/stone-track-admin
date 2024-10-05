using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneTrackAdmin.Models;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private readonly IBasicUtility _basic;
        private readonly IMaterial _material;
        public MaterialController(IBasicUtility basic, IMaterial material)
        {
            _material = material;
            _basic = basic;
        }

        [HttpGet]
        public async Task<IActionResult> MaterialDetail()
        {
            var result = await _material.MaterialDetails();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMaterial(int MaterialID)
        {
            await _material.DeleteMaterialDetails(MaterialID);

            var response = new
            {
                status = true,
                Msg = "Material Deleted",
                data = ""
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddMaterial(int MaterialID = 0)
        {
            if (MaterialID > 0)
            {
                var result = await _material.GetMaterialDetailsById(MaterialID);
                return View(result);
            }
            else
            {
                MaterialModel obj = new MaterialModel();
                obj.MaterialID = MaterialID;
                return View(obj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterial(MaterialModel Viewmodel)
        {
            if (Viewmodel.MaterialID > 0)
            {
                await _material.UpdateMaterial(Viewmodel);
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            else
            {
                await _material.InsertMaterial(Viewmodel);
                TempData["SuccessMessage"] = "Record Added Successfully";
            }

            return RedirectToAction("MaterialDetail", "Material");
        }

    }
}
