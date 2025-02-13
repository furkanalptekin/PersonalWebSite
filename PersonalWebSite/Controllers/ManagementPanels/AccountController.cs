﻿using AutoMapper;
using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalWebSite.Controllers.ManagementPanels
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _repository = new AccountRepository();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            ILogger<LoginViewModel> logger,
            UserManager<ApplicationUser> userManager, 
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("NAME", user.NameSurname);
                        return Redirect(ReturnUrl);
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        //TODO LOCKOUT SAYFASI
                        return RedirectToPage("./Lockout");
                    }
                }
                ModelState.AddModelError(string.Empty, "Kullanıcı Adı/Şifre yanlış!");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.FindFirstValue(ClaimTypes.Name) != null)
            {
                HttpContext.Session.Clear();
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            return Json(new { success = await _repository.Delete(_userManager, id) });
        }

        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            return Json(new { success = true, data = _repository.GetList(_userManager).ToJsonList() });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Operations()
        {
            ViewBag.Update = false;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Operations(AccountViewModel model)
        {
            ViewBag.Update = false;
            if (ModelState.IsValid)
            {
                ViewBag.Alert = await _repository.Add(model, _userManager);
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Show(string id)
        {
            ViewBag.Show = true;
            ViewBag.Update = false;
            var account = _repository.GetFromId(_userManager, id).Result;
            if (account != null)
            {
                return View("Operations", _mapper.Map<AccountViewModel>(account));
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update(string Id)
        {
            ViewBag.Update = true;
            AccountViewModel acc = _mapper.Map<AccountViewModel>(await _repository.GetFromId(_userManager, Id));
            if (acc != null)
            {
                HttpContext.Session.SetString("UPDATESTR", acc.Id);
                return View("Operations", acc);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDb(AccountViewModel model)
        {
            ViewBag.Update = true;
            if (ModelState.IsValid)
            {
                var id = HttpContext.Session.GetString("UPDATESTR");
                if (!string.IsNullOrEmpty(id))
                {
                    model.Id = id;
                    TempData["Alert"] = await _repository.Update(model, _userManager);
                    HttpContext.Session.SetString("UPDATESTR", string.Empty);
                    ModelState.Clear();
                }
                return RedirectToAction("Operations");
            }
            return View("Operations");
        }
    }
}