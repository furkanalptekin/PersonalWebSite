using System;

namespace DB.Models
{
    public partial class SosyalMedya
    {
        public int Id { get; set; }
        public string SosyalMedyaAdi { get; set; }
        public string Adres { get; set; }
        public string Ikon { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}