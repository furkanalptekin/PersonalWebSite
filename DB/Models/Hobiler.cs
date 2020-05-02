using System;

namespace DB.Models
{
    public partial class Hobiler
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Ikon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}