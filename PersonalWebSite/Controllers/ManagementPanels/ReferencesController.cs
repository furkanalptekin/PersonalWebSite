using DB.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class ReferencesController : Controller, IControllerFunctions<Referanslar>
    {
        readonly IDatabaseFunctions<Referanslar, Referanslar> logic = new ReferenceLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = JsonLogic<Referanslar>.ListToJson(logic.GetList()) });
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
        public IActionResult Operations(Referanslar model)
        {
            ViewBag.Update = false;
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
            var references = logic.GetFromId(id);
            if (references != null)
            {
                return View("Operations", references);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            var references = logic.GetFromId(id);
            if (references != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", references.Id);
                return View("Operations", references);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(Referanslar model)
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
    }
}