using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Hobiler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hobi Adı Boş Geçilemez."), MaxLength(255)]
        public string Adi { get; set; }
        public string Ikon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}