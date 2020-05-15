using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class EducationController : Controller, IControllerFunctions<Egitim>
    {
        private readonly IDatabaseFunctions<Egitim, Egitim> logic = new EducationLogic();
        private readonly DropDownLists lists = new DropDownLists();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<Egitim>.ListToJson(logic.GetList()) });
        }

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            ViewBag.EducationTypes = lists.GetEducationTypes();
            ViewBag.Cities = lists.GetCities();
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Egitim model)
        {
            ViewBag.Update = false;
            ViewBag.EducationTypes = lists.GetEducationTypes();
            ViewBag.Cities = lists.GetCities();
            if (ModelState.IsValid)
            {
                ViewBag.Alert = logic.Add(model);
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Show(int? id)
        {
            ViewBag.Show = true;
            ViewBag.Update = false;
            ViewBag.EducationTypes = lists.GetEducationTypes();
            ViewBag.Cities = lists.GetCities();
            var edu = logic.GetFromId(id);
            if (edu != null)
            {
                ViewBag.Districts = lists.GetDistricts((int)edu.SehirId, false);
                return View("Operations", edu);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            ViewBag.EducationTypes = lists.GetEducationTypes();
            ViewBag.Cities = lists.GetCities();
            var edu = logic.GetFromId(id);
            if (edu != null)
            {
                ViewBag.Districts = lists.GetDistricts((int)edu.SehirId, false);
                HttpContext.Session.SetInt32("UPDATEID", edu.Id);
                return View("Operations", edu);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(Egitim model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.Id = (int)id;
                TempData["Alert"] = logic.Update(model);
                HttpContext.Session.SetInt32("UPDATEID", -1);
                ModelState.Clear();
            }
            return RedirectToAction("Operations");
        }

        [HttpPost]
        public JsonResult GetDistricts(int CityId)
        {
            return Json(lists.GetDistricts(CityId, false));
        }
    }
}