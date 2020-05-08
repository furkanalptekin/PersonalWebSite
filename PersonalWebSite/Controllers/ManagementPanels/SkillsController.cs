using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Add()
        {
            ViewBag.Update = false;
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Yetenekler model)
        {
            ViewBag.Update = false;
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            if (ModelState.IsValid)
            {
                bool success = logic.Add(model);
                if (success)
                {
                    ModelState.Clear();
                }
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
                return View("Add", cat);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateDb(Yetenekler model)
        {
            ViewBag.Update = true;
            ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
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