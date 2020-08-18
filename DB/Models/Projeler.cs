using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Projeler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proje Adı Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Adi { get; set; }
        public string Link { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        [Required(ErrorMessage = "Kullanılan Diller Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string KullanilanDiller { get; set; }
        [Required(ErrorMessage = "Proje Açıklaması Boş Geçilemez.")]
        public string Aciklama { get; set; }
        public string YapilisNedeni { get; set; }
        public string Kategori { get; set; }
        public bool Aktif { get; set; } = true;
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }
    }
}