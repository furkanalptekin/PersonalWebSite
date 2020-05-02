using DB.ViewModels;
using DB.Models;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

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
                        string hash = null;
                        using (SHA256 sha = SHA256.Create())
                        {
                            StringBuilder builder = new StringBuilder();
                            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                            for (int i = 0; i < bytes.Length; i++)
                                builder.Append(bytes[i].ToString("x2"));
                            
                            hash = builder.ToString();
                        }
                        if (hesap.Sifre == hash)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}