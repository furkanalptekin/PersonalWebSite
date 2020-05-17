using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Hesap
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez."), MaxLength(50)]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Ad Soyad Bilgisi Boş Geçilemez."), MaxLength(50)]
        public string AdSoyad { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}