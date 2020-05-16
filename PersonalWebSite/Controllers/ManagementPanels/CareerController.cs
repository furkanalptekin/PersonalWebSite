using System;
using DB.ViewModels;
using Logic.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;
using DB.DataModels;
using Microsoft.AspNetCore.Http;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class CareerController : Controller, IControllerFunctions<CareerViewModel>
    {
        private readonly CareerLogic logic = new CareerLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<CareerDataModel>.ListToJson(logic.GetDataModelList()) });
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
        [ValidateAntiForgeryToken]
        public IActionResult Operations(CareerViewModel model)
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
            var carrer = logic.GetFromId(id);
            if (carrer != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", carrer.Id);
                return View("Operations", new CareerViewModel() { MeslekiDeneyim = carrer });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(CareerViewModel model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.MeslekiDeneyim.Id = (int)id;
                TempData["Alert"] = logic.Update(model);
                HttpContext.Session.SetInt32("UPDATEID", -1);
                ModelState.Clear();
            }
            return RedirectToAction("Operations");
        }
    }
}