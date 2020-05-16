using System;
using System.Runtime.InteropServices.WindowsRuntime;
using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class PersonController : Controller, IControllerFunctions<PersonViewModel>
    {
        private readonly DropDownLists lists = new DropDownLists();
        private readonly PersonLogic logic = new PersonLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Operations()
        {
            if (logic.GetPerson() == null)
            {
                ViewBag.Update = false;
                ViewBag.Cities = lists.GetCities();
                if (TempData["Alert"] != null)
                    ViewBag.Alert = (bool)TempData["Alert"];
                return View();
            }
            return RedirectToAction("Update", "Person", 0);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(PersonViewModel model)
        {
            ViewBag.Update = false;
            ViewBag.Cities = lists.GetCities();
            if (ModelState.IsValid)
            {
                ViewBag.Alert = logic.Add(model);
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Show(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            ViewBag.Cities = lists.GetCities();
            var model = logic.GetPersonViewModel();
            if (model != null)
            {
                ViewBag.DogumDistricts = lists.GetDistricts((int)model.Kisi.DogumSehirId, false);
                ViewBag.KonumDistricts = lists.GetDistricts((int)model.Kisi.KonumSehirId, false);
                return View("Operations", model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(PersonViewModel model)
        {
            ViewBag.Update = true;
            TempData["Alert"] = logic.Update(model);
            ModelState.Clear();
            return RedirectToAction("Operations");
        }

        [HttpPost]
        public JsonResult GetDistricts(int CityId)
        {
            return Json(lists.GetDistricts(CityId, false));
        }
    }
}