using System;

namespace DB.Models
{
    public partial class MeslekiDeneyim
    {
        public int Id { get; set; }
        public string Firma { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public string Pozisyon { get; set; }
        public string Adres { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}