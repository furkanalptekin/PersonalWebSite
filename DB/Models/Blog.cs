using System;

namespace DB.Models
{
    public partial class Blog
    {
        public long Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Detay { get; set; }
        public DateTime GosterimBaslangicTarihi { get; set; }
        public DateTime? GosterimBitisTarihi { get; set; }
        public string Fotograf { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}