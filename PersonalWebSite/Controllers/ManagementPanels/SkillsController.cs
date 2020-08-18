using AutoMapper;
using DB.Dtos;
using DB.Models;
using Logic;
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
    public class SkillsController : Controller, IControllerFunctions<Yetenekler>
    {
        private readonly ISkillsRepository _repository;
        private readonly IMapper _mapper;
        private readonly DropDownLists _lists;

        public SkillsController(ISkillsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _lists = new DropDownLists();
        }

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.SkillCategories = _lists.GetSkillCategories();
            return this.AddExtension(Views.Operations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Yetenekler model)
        {
            ViewBag.SkillCategories = _lists.GetSkillCategories();
            return this.AddDbExtension(_repository, model, Views.Operations);
        }

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _mapper.Map<IList<SkillsDto>>(_repository.Where(x => x.Aktif)).ToJsonList() });

        [HttpGet]
        public IActionResult Show(int? id) => NotFound();

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.SkillCategories = _lists.GetSkillCategories();
            return this.UpdateExtension(_repository, id, Views.Operations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(Yetenekler model)
        {
            ViewBag.SkillCategories = _lists.GetSkillCategories();
            return this.UpdateDbExtension(_repository, model, Views.Operations);
        }
    }
}