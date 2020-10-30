using AutoMapper;
using DB.Models;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class CVController : Controller, IControllerFunctions<Cv>
    {
        private readonly ICvRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CVController(ICvRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations.ToString());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Cv model)
        {
            return this.AddDbExtension(
                _repository, 
                model, 
                Views.Operations.ToString(), 
                new { File = HttpContext.Request.Form.Files["File"], FolderName = "CV", wwwrootPath = _hostingEnvironment.WebRootPath}
                );
        }

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List()
        {
            return Json(new { success = true, data = _repository.Where(x => x.Aktif).ToJsonList() });
        }

        [HttpPost]
        public IActionResult Show(int? id)
        {
            var cv = _repository.GetFromId(id);
            if (cv != null)
                return Json(new { success = true, b64 = cv.CvToBase64(_hostingEnvironment.WebRootPath), CvName = cv.CvAdi });

            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Update(int? id) => throw new System.NotImplementedException();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(Cv model) => throw new System.NotImplementedException();
    }
}