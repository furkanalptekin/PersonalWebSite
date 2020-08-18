using AutoMapper;
using DB.Models;
using DB.ViewModels;
using Logic;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class CareerController : Controller, IControllerFunctions<CareerViewModel>
    {
        private readonly ICareerRepository _repository;
        private readonly IMapper _mapper;

        public CareerController(ICareerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _repository.Where(x => x.Aktif).ToJsonList() });

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(CareerViewModel model) => this.AddDbExtension(_repository, model, Views.Operations);

        [HttpGet]
        public IActionResult Show(int? id) => throw new NotImplementedException();

        [HttpGet]
        public IActionResult Update(int? id) => this.UpdateExtensionMapper<MeslekiDeneyim, CareerViewModel>(_repository, _mapper, id, Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(CareerViewModel model) => this.UpdateDbExtension(_repository, model, Views.Operations);
    }
}