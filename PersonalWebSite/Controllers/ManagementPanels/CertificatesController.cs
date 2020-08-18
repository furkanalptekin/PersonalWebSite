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
    public class CertificatesController : Controller, IControllerFunctions<Sertifikalar>
    {
        private readonly ICertificateRepository _repository;

        public CertificatesController(ICertificateRepository repository) => _repository = repository;

        [HttpPost]
        public IActionResult Delete(int? id) => Json(new { success = _repository.Remove(id) });

        [HttpGet]
        public IActionResult List() => Json(new { success = true, data = _repository.Where(x => x.Aktif).ToJsonList() });

        [HttpGet]
        public IActionResult Operations() => this.AddExtension(Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operations(Sertifikalar model) => this.AddDbExtension(_repository, model, Views.Operations);

        [HttpGet]
        public IActionResult Show(int? id) => this.ShowExtension(_repository, id, Views.Operations);

        [HttpGet]
        public IActionResult Update(int? id) => this.UpdateExtension(_repository, id, Views.Operations);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUpdateId]
        public IActionResult UpdateDb(Sertifikalar model) => this.UpdateDbExtension(_repository, model, Views.Operations);
    }
}