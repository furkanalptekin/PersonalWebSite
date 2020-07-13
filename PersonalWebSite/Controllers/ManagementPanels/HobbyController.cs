﻿using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class HobbyController : Controller, IControllerFunctions<HobbyViewModel>
    {
        private readonly HobbyLogic logic = new HobbyLogic();

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = logic.Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = logic.GetDataModelList().ToJsonList() });
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
        public IActionResult Operations(HobbyViewModel model)
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
            var hobby = logic.GetFromId(id);
            if (hobby != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", hobby.Id);
                return View("Operations", new HobbyViewModel() { Hobiler = hobby });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(HobbyViewModel model)
        {
            ViewBag.Update = true;
            var id = HttpContext.Session.GetInt32("UPDATEID");
            if (id != null && id != -1)
            {
                model.Hobiler.Id = (int)id;
                TempData["Alert"] = logic.Update(model);
                HttpContext.Session.SetInt32("UPDATEID", -1);
                ModelState.Clear();
            }
            return RedirectToAction("Operations");
        }
    }
}