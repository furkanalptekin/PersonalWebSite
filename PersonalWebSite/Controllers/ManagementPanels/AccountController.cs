﻿using DB.Models;
using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class AccountController : Controller, IControllerFunctions<Hesap>
    {
        private readonly IDatabaseFunctions<Hesap, Hesap> logic = new AccountLogic();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var login = new LoginLogic().Login(model);
                if (login)
                {
                    HttpContext.Session.SetString("ADMIN", "asd");
                    return RedirectToAction("Index", "Home");
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
            return Json(new { success = true, data = JsonLogic<Hesap>.ListToJson(logic.GetList()) });
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
        public IActionResult Operations(Hesap model)
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
            var project = logic.GetFromId(id);
            if (project != null)
            {
                return View("Operations", project);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            var acc = logic.GetFromId(id);
            if (acc != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", acc.Id);
                return View("Operations", acc);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(Hesap model)
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