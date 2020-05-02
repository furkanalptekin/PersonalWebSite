using System;

namespace DB.Models
{
    public partial class Sertifikalar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Brans { get; set; }
        public string Firma { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? GecerlilikSuresi { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}