using DB.Models;
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
    public class LanguagesController : Controller, IControllerFunctions<YabanciDil>
    {
        private readonly ILanguageRepository _repository;
        private readonly DropDownLists _lists;

        public LanguagesController(ILanguageRepository repository)
        {
            _repository = repository;
            _lists = new DropDownLists();
        }

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _repository.Where(x => x.Aktif).ToJsonList() });

        [HttpGet]
        public IActionResult Operations()
        {
            ViewBag.RatingA1 = _lists.GetLanguageRating(true);
            ViewBag.Rating = _lists.GetLanguageRating(false);
            return this.AddExtension(Views.Operations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(YabanciDil model)
        {
            ViewBag.RatingA1 = _lists.GetLanguageRating(true);
            ViewBag.Rating = _lists.GetLanguageRating(false);
            return this.AddDbExtension(_repository, model, Views.Operations);
        }

        [HttpGet]
        public IActionResult Show(int? id) => throw new NotImplementedException();

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.RatingA1 = _lists.GetLanguageRating(true);
            ViewBag.Rating = _lists.GetLanguageRating(false);
            return this.UpdateExtension(_repository, id, Views.Operations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(YabanciDil model)
        {
            ViewBag.RatingA1 = _lists.GetLanguageRating(true);
            ViewBag.Rating = _lists.GetLanguageRating(false);
            return this.UpdateDbExtension(_repository, model, Views.Operations);
        }
    }
}