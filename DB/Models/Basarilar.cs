using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Basarilar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Firma Bilgisi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Firma { get; set; }
        public string Tarih { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Boş Geçilemez.")]
        public string Aciklama { get; set; }
        public bool Aktif { get; set; } = true;
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }
    }
}