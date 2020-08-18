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
    public class HobbyController : Controller, IControllerFunctions<HobbyViewModel>
    {
        private readonly IHobbyRepository _repository;
        private readonly IMapper _mapper;

        public HobbyController(IHobbyRepository repository, IMapper mapper)
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
        public IActionResult Operations(HobbyViewModel model) => this.AddDbExtension(_repository, model, Views.Operations);

        [HttpGet]
        public IActionResult Show(int? id) => throw new NotImplementedException();

        [HttpGet]
        public IActionResult Update(int? id) => this.UpdateExtensionMapper<Hobiler, HobbyViewModel>(_repository, _mapper, id, Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(HobbyViewModel model) => this.UpdateDbExtension(_repository, model, Views.Operations);
    }
}