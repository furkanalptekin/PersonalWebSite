using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Sertifikalar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sertifika Adı Boş Geçilemez."), MaxLength(255)]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Branş Boş Geçilemez."), MaxLength(255)]
        public string Brans { get; set; }
        public string Firma { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? GecerlilikSuresi { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}