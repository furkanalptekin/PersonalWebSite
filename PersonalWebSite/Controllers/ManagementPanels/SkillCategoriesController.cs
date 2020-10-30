using DB.Models;
using Logic;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class SkillCategoriesController : Controller, IControllerFunctions<YetenekKategori>
    {
        private readonly ISkillCategoriesRepository _repository;

        public SkillCategoriesController(ISkillCategoriesRepository repository) => _repository = repository;

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations.ToString());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(YetenekKategori model) => this.AddDbExtension(_repository, model, Views.Operations.ToString());

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _repository.Where(x => x.Aktif).ToJsonList() });

        [HttpGet]
        public IActionResult Show(int? id) => NotFound();

        [HttpGet]
        public IActionResult Update(int? id) => this.UpdateExtension(_repository, id, Views.Operations.ToString());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(YetenekKategori model) => this.UpdateDbExtension(_repository, model, Views.Operations.ToString());
    }
}