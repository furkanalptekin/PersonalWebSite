using System;
using DB.Models;
using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class LanguagesController : Controller, IControllerFunctions<YabanciDil>
    {
        private readonly IDatabaseFunctions<YabanciDil, YabanciDil> logic = new ForeignLanguagesLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<YabanciDil>.ListToJson(logic.GetList()) });
        }

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];
            DropDownLists lists = new DropDownLists();
            ViewBag.RatingA1 = lists.GetLanguageRating(true);
            ViewBag.Rating = lists.GetLanguageRating(false);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(YabanciDil model)
        {
            ViewBag.Update = false;
            DropDownLists lists = new DropDownLists();
            ViewBag.RatingA1 = lists.GetLanguageRating(true);
            ViewBag.Rating = lists.GetLanguageRating(false);
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
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            DropDownLists lists = new DropDownLists();
            ViewBag.RatingA1 = lists.GetLanguageRating(true);
            ViewBag.Rating = lists.GetLanguageRating(false);
            var lang = logic.GetFromId(id);
            if (lang != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", lang.Id);
                return View("Operations", lang);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(YabanciDil model)
        {
            ViewBag.Update = true;
            DropDownLists lists = new DropDownLists();
            ViewBag.RatingA1 = lists.GetLanguageRating(true);
            ViewBag.Rating = lists.GetLanguageRating(false);
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
    }
}