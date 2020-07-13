using DB.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class CVController : Controller, IControllerFunctions<CvFileModel>
    {
        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.List = new CvLogic().GetList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(CvFileModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Alert = new CvLogic().Add(model);
                ModelState.Clear();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = new CvLogic().Delete(id) });
        }

        [HttpGet]
        public IActionResult List()
        {
            CvLogic logic = new CvLogic();
            return Json(new { success = true, data = logic.ConvertToDataModel(logic.GetList()).ToJsonList() });
        }

        [HttpPost]
        public IActionResult Show(int? id)
        {
            var cv = new CvLogic().GetFromId(id);
            if (cv != null)
                return Json(new { success = true, cv.B64, CvName = cv.CvAdi });

            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(CvFileModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}