using DB.Models;
using Logic;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class EducationController : Controller, IControllerFunctions<Egitim>
    {
        private readonly IEducationRepository _repository;
        private readonly DropDownLists _lists;

        public EducationController(IEducationRepository repository)
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
            ViewBag.EducationTypes = _lists.GetEducationTypes();
            ViewBag.Cities = _lists.GetCities();
            return this.AddExtension(Views.Operations.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Egitim model)
        {
            ViewBag.EducationTypes = _lists.GetEducationTypes();
            ViewBag.Cities = _lists.GetCities();
            return this.AddDbExtension(_repository, model, Views.Operations.ToString());
        }

        [HttpGet]
        public IActionResult Show(int? id)
        {
            ViewBag.Show = true;
            ViewBag.Update = false;
            ViewBag.EducationTypes = _lists.GetEducationTypes();
            ViewBag.Cities = _lists.GetCities();
            var edu = _repository.GetFromId(id);
            if (edu != null)
            {
                ViewBag.Districts = _lists.GetDistricts((int)edu.SehirId, false);
                return View("Operations", edu);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            ViewBag.EducationTypes = _lists.GetEducationTypes();
            ViewBag.Cities = _lists.GetCities();
            var edu = _repository.GetFromId(id);
            if (edu != null)
            {
                ViewBag.Districts = _lists.GetDistricts((int)edu.SehirId, false);
                HttpContext.Session.SetInt32("UPDATEID", edu.Id);
                return View("Operations", edu);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(Egitim model)
        {
            ViewBag.EducationTypes = _lists.GetEducationTypes();
            ViewBag.Cities = _lists.GetCities();
            return this.UpdateDbExtension(_repository, model, Views.Operations.ToString());
        }

        [HttpPost]
        public JsonResult GetDistricts(int CityId) => Json(_lists.GetDistricts(CityId, false));
    }
}