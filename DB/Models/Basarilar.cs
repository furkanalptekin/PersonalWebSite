using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Basarilar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Boş Geçilemez."), MaxLength(255)]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Firma Bilgisi Boş Geçilemez."), MaxLength(255)]
        public string Firma { get; set; }
        public string Tarih { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Boş Geçilemez.")]
        public string Aciklama { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}