using DB.Models;
using DB.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public class AccountLogic
    {
        public async Task<bool> Add(AccountViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null && parameters.Length != 0)
            {
                UserManager<ApplicationUser> userManager = parameters[0] as UserManager<ApplicationUser>;
                var created = await userManager.CreateAsync(new ApplicationUser()
                {
                    Email = model.Email,
                    EmailConfirmed = true,
                    UserName = model.AdSoyad.Split(' ').Length == 0 ? model.AdSoyad : model.AdSoyad.Split(' ')[0],
                    NameSurname = model.AdSoyad,
                    EklemeTarihi = DateTime.Now
                }, model.Sifre);
                success = created.Succeeded;
            }
            return success;
        }

        public async Task<bool> Delete(UserManager<ApplicationUser> userManager, string Id)
        {
            bool success = false;
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var taskResult = await userManager.DeleteAsync(user);
                success = taskResult.Succeeded;
            }
            return success;
        }

        public async Task<AccountViewModel> GetFromId(UserManager<ApplicationUser> userManager, string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
                return new AccountViewModel()
                {
                    Id = user.Id,
                    AdSoyad = user.NameSurname,
                    UserName = user.UserName,
                    Email = user.Email,
                    EklemeTarihi = user.EklemeTarihi,
                    DegisimTarihi = user.DegisimTarihi
                };

            return null;
        }

        public List<AccountViewModel> GetList(UserManager<ApplicationUser> userManager)
        {
            List<AccountViewModel> accounts = new List<AccountViewModel>();
            foreach (var user in userManager.Users)
                accounts.Add(new AccountViewModel()
                {
                    Id = user.Id,
                    AdSoyad = user.NameSurname,
                    UserName = user.UserName,
                    Email = user.Email,
                    EklemeTarihi = user.EklemeTarihi,
                    DegisimTarihi = user.DegisimTarihi
                });

            return accounts;
        }

        public async Task<bool> Update(AccountViewModel model, UserManager<ApplicationUser> userManager)
        {
            bool success = false;
            if (model != null)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.NameSurname = model.AdSoyad;
                    user.UserName = model.UserName;
                    user.DegisimTarihi = DateTime.Now;
                    var result = await userManager.UpdateAsync(user);
                    var result2 = await userManager.ChangePasswordAsync(user, model.EskiSifre, model.Sifre);
                    success = result.Succeeded & result2.Succeeded;
                }
            }
            return success;
        }
    }
}