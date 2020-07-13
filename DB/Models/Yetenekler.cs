using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Yetenekler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Yetenek Adı Boş Geçilemez."), MaxLength(10, ErrorMessage = "Maksimum 10 Karakter Olabilir.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Başarı Oranı Boş Geçilemez.")]
        public int? BasariOrani { get; set; }
        public string RenkKodu { get; set; }
        [Required(ErrorMessage = "Yetenek Kategorisi Boş Geçilemez.")]
        public int? KategoriId { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }

        public virtual YetenekKategori Kategori { get; set; }
    }
}