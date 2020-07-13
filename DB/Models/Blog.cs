using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık Boş Geçilemez."), MaxLength(120, ErrorMessage = "Maksimum 120 Karakter Olabilir.")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Özet Boş Geçilemez."), MaxLength(400, ErrorMessage = "Maksimum 400 Karakter Olabilir.")]
        public string Ozet { get; set; }
        [Required(ErrorMessage = "İçerik Boş Geçilemez.")]
        public string Detay { get; set; }
        public DateTime GosterimBaslangicTarihi { get; set; }
        public DateTime? GosterimBitisTarihi { get; set; }
        public string Fotograf { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}