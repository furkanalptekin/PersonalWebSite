using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Hobiler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hobi Adı Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Adi { get; set; }
        public string Ikon { get; set; }
        public bool Aktif { get; set; } = true;
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }
    }
}