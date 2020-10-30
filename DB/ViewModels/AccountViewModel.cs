using System;
using System.ComponentModel.DataAnnotations;

namespace DB.ViewModels
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Boş Geçilemez."), MaxLength(256, ErrorMessage = "Maksimum 256 Karakter Olabilir.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Geçilemez."), MaxLength(256, ErrorMessage = "Maksimum 256 Karakter Olabilir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez.")]
        public string Sifre { get; set; }
        public string EskiSifre { get; set; }
        [Required(ErrorMessage = "Ad Soyad Bilgisi Boş Geçilemez."), MaxLength(256, ErrorMessage = "Maksimum 256 Karakter Olabilir.")]
        public string NameSurname { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}