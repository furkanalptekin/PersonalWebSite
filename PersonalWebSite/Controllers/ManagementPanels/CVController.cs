using AutoMapper;
using DB.Dtos;
using DB.ViewModels;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class CVController : Controller, IControllerFunctions<CvViewModel>
    {
        private readonly ICvRepository _repository;
        private readonly IMapper _mapper;

        public CVController(ICvRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(CvViewModel model) => this.AddDbExtension(_repository, model, Views.Operations);

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _mapper.Map<IList<CvDto>>(_repository.Where(x => x.Aktif)).ToJsonList() });

        [HttpPost]
        public IActionResult Show(int? id)
        {
            var cv = _repository.GetFromId(id);
            if (cv != null)
                return Json(new { success = true, cv.B64, CvName = cv.CvAdi });

            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Update(int? id) => throw new System.NotImplementedException();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDb(CvViewModel model) => throw new System.NotImplementedException();
    }
}