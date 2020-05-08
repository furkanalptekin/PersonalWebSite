using System;
using System.Net;
using DB.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class SkillCategoriesController : Controller, IControllerFunctions<YetenekKategori>
    {
        readonly IDatabaseFunctions<YetenekKategori, YetenekKategori> logic = new SkillCategoriesLogic();

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Update = false;
            return View();
        }

        [HttpPost]
        public IActionResult Add(YetenekKategori model)
        {
            ViewBag.Update = false;
            if (ModelState.IsValid)
            {
                logic.Add(model);
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
            return Json(new { success = true, data = JsonLogic<YetenekKategori>.ListToJson(logic.GetList()) });
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
            var cat = logic.GetFromId(id);
            if (cat != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", cat.Id);
                return View("Add", cat);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateDb(YetenekKategori model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.Id = (int)id;
                bool success = logic.Update(model);
                if (success)
                {
                    HttpContext.Session.SetInt32("UPDATEID", -1);
                    ModelState.Clear();
                    return View("Add");
                }
            }
            return View("Add");
        }
    }
}