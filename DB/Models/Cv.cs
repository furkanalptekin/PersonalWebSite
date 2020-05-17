using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Cv
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CV Adı Boş Geçilemez."), MaxLength(255)]
        public string CvAdi { get; set; }
        public string B64 { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}