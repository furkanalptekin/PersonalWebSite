using System;
using DB.ViewModels;
using Logic.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DB.DataModels;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class HobbyController : Controller, IControllerFunctions<HobbyViewModel>
    {
        readonly HobbyLogic logic = new HobbyLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<HobbyDataModel>.ListToJson(logic.GetDataModelList()) });
        }

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            return View();
        }

        [HttpPost]
        public IActionResult Operations(HobbyViewModel model)
        {
            ViewBag.Update = false;
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

        [HttpGet]
        public IActionResult Show(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            var hobby = logic.GetFromId(id);
            if (hobby != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", hobby.Id);
                return View("Operations", new HobbyViewModel() { Hobiler = hobby });
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateDb(HobbyViewModel model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.Hobiler.Id = (int)id;
                bool success = logic.Update(model);
                if (success)
                {
                    HttpContext.Session.SetInt32("UPDATEID", -1);
                    ModelState.Clear();
                }
            }
            return RedirectToAction("Operations");
        }
    }
}