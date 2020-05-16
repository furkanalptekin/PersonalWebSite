using System;
using DB.DataModels;
using DB.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class SkillsController : Controller, IControllerFunctions<Yetenekler>
    {
        readonly SkillsLogic logic = new SkillsLogic();

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Yetenekler model)
        {
            ViewBag.Update = false;
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            if (ModelState.IsValid)
            {
                ViewBag.Alert = logic.Add(model);
                ModelState.Clear();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<SkillsDataModel>.ListToJson(logic.GetDataModelList()) });
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
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            var cat = logic.GetFromId(id);
            if (cat != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", cat.Id);
                return View("Operations", cat);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(Yetenekler model)
        {
            ViewBag.Update = true;
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
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