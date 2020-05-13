using System;
using DB.DataModels;
using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class SocialMediaController : Controller, IControllerFunctions<SocialMediaViewModel>
    {
        private readonly SocialMediaLogic logic = new SocialMediaLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<SocialMediaDataModel>.ListToJson(logic.GetDataModelList()) });
        }

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];
            return View();
        }

        [HttpPost]
        public IActionResult Operations(SocialMediaViewModel model)
        {
            ViewBag.Update = false;
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Alert = logic.Add(model);
                    ModelState.Clear();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Show(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            var socialMedia = logic.GetFromId(id);
            if (socialMedia != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", socialMedia.Id);
                return View("Operations", new SocialMediaViewModel() { SosyalMedya = socialMedia });
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateDb(SocialMediaViewModel model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.SosyalMedya.Id = (int)id;
                TempData["Alert"] = logic.Update(model);
                HttpContext.Session.SetInt32("UPDATEID", -1);
                ModelState.Clear();
            }
            return RedirectToAction("Operations");
        }
    }
}