using AutoMapper;
using DB.Dtos;
using DB.ViewModels;
using Logic;
using Logic.Enums;
using Logic.Extensions;
using Logic.Interfaces;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    [Authorize]
    public class BlogController : Controller, IControllerFunctions<BlogViewModel>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public BlogController(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _mapper.Map<IList<BlogDto>>(_repository.Where(x => x.Aktif)).ToJsonList() });

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(BlogViewModel model) => this.AddDbExtension(_repository, model, Views.Operations);

        [HttpGet]
        public IActionResult Show(int? id)
        {
            ViewBag.Show = true;
            ViewBag.Update = false;
            var blog = _repository.GetFromIdAndDecode(id);
            if (blog != null)
            {
                return View("Operations", _mapper.Map<BlogViewModel>(blog));
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.Update = true;
            var blog = _repository.GetFromIdAndDecode(id);
            if (blog != null)
            {
                HttpContext.Session.SetInt32("UPDATEID", blog.Id);
                return View("Operations", _mapper.Map<BlogViewModel>(blog));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(BlogViewModel model) => this.UpdateDbExtension(_repository, model, Views.Operations);
    }
}