using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class MeslekiDeneyim
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Firma Bilgisi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Firma { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        [Required(ErrorMessage = "Pozisyon Bilgisi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Pozisyon { get; set; }
        public string Adres { get; set; }
        public bool Aktif { get; set; } = true;
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }
        public string FirmaIcon { get; set; }
    }
}