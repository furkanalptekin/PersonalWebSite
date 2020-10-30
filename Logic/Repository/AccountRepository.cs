using DB.Models;
using DB.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repository
{
    public class AccountRepository
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
                    UserName = model.UserName,
                    NameSurname = model.NameSurname,
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

        public async Task<ApplicationUser> GetFromId(UserManager<ApplicationUser> userManager, string Id)
        {
            return await userManager.FindByIdAsync(Id);
        }

        public IList<ApplicationUser> GetList(UserManager<ApplicationUser> userManager)
        {
            return userManager.Users.ToList();
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
                    user.NameSurname = model.NameSurname;
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