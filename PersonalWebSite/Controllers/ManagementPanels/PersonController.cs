using AutoMapper;
using DB.ViewModels;
using Logic;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class PersonController : Controller, IControllerFunctions<PersonViewModel>
    {
        private readonly DropDownLists _lists;
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _lists = new DropDownLists();
        }

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        public IActionResult List() => NotFound();

        [HttpGet]
        public IActionResult Operations()
        {
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];

            if (_repository.GetPerson() == null)
            {
                ViewBag.Update = false;
                ViewBag.Cities = _lists.GetCities();
                return View();
            }
            return RedirectToAction("Update", "Person", 0);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(PersonViewModel model)
        {
            ViewBag.Cities = _lists.GetCities();
            return this.AddDbExtension(_repository, model, Views.Operations.ToString());
        }

        public IActionResult Show(int? id) => throw new NotImplementedException();

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (TempData["Alert"] != null)
                ViewBag.Alert = (bool)TempData["Alert"];

            ViewBag.Update = true;
            ViewBag.Cities = _lists.GetCities();
            var model = _repository.GetPersonViewModel(_mapper);
            if (model != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", model.Id);
                ViewBag.DogumDistricts = _lists.GetDistricts((int)model.DogumSehirId, false);
                ViewBag.KonumDistricts = _lists.GetDistricts((int)model.KonumSehirId, false);
                return View("Operations", model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(PersonViewModel model)
        {
            ViewBag.Cities = _lists.GetCities();
            ViewBag.DogumDistricts = _lists.GetDistricts((int)model.DogumSehirId, false);
            ViewBag.KonumDistricts = _lists.GetDistricts((int)model.KonumSehirId, false);
            return this.UpdateDbExtension(_repository, model, Views.Operations.ToString());
        }

        [HttpPost]
        public JsonResult GetDistricts(int CityId) => Json(_lists.GetDistricts(CityId, false));
    }
}
