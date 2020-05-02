using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class CVController : Controller, IControllerFunctions<CvFileModel>
    {
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.List = new CvLogic().GetList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CvFileModel model)
        {
            new CvLogic().Add(model);
            return RedirectToAction("Add");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = new CvLogic().Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IActionResult Show(int? id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IActionResult Update()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(CvFileModel model)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IActionResult UpdatePage(int? id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public JsonResult GetPDF(int? id)
        {
            var cv = new CvLogic().GetFromId(id);
            return Json(new { B64 = cv.B64, CvName = cv.CvAdi });
        }
    }
}