using DB.ViewModels;
using DB.Models;
using System.Linq;

namespace Logic
{
    public class LoginLogic
    {
        public bool Login(LoginViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var hesap = db.Hesap.Where(x => x.KullaniciAdi == model.Email).FirstOrDefault();
                    if (hesap != null)
                    {
                        if (hesap.Sifre == Sha256Helper.Hash(model.Password))
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}