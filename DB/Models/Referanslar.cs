using System;

namespace DB.Models
{
    public partial class Referanslar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Meslek { get; set; }
        public string Firma { get; set; }
        public string Pozisyon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}