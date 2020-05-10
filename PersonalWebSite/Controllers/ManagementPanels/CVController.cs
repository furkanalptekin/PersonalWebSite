using DB.ViewModels;
using DB.DataModels;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
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
            new CvLogic().Add(model);
            return RedirectToAction("Operations");
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
            return Json(new { success = true, data = JsonLogic<CvDataModel>.ListToJson(logic.ConvertToDataModel(logic.GetList())) });
        }

        [HttpPost]
        public IActionResult Show(int? id)
        {
            var cv = new CvLogic().GetFromId(id);
            if (cv != null)
                return Json(new { success = true, B64 = cv.B64, CvName = cv.CvAdi });

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