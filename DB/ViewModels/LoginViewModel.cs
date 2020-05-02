using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress), Required(ErrorMessage = "E-mail Adresi Boş Bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçersiz E-mail Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Şifre Boş Bırakılamaz.")]
        public string Password { get; set; }
    }
}