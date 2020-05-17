using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Referanslar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Referansın Adı Boş Geçilemez."), MaxLength(255)]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Referansın Soyadı Boş Geçilemez."), MaxLength(255)]
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        [Required(ErrorMessage = "E-Posta Bilgisi Boş Geçilemez."), MaxLength(255)]
        public string Eposta { get; set; }
        public string Meslek { get; set; }
        public string Firma { get; set; }
        public string Pozisyon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}