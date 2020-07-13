using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class YabanciDil
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dil Adı Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Dil Seviyesi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Seviyesi { get; set; }
        [Required(ErrorMessage = "Okuma Seviyesi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string OkumaSeviyesi { get; set; }
        [Required(ErrorMessage = "Yazma Seviyesi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string YazmaSeviyesi { get; set; }
        [Required(ErrorMessage = "Konuşma Seviyesi Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string KonusmaSeviyesi { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}