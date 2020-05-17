using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class SosyalMedya
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sosyal Medya Adı Boş Geçilemez."), MaxLength(255)]
        public string SosyalMedyaAdi { get; set; }
        [Required(ErrorMessage = "Sosyal Medya Adresiniz Boş Geçilemez."), MaxLength(255)]
        public string Adres { get; set; }
        public string Ikon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}