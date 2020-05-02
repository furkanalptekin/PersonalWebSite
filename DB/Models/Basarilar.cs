using System;

namespace DB.Models
{
    public partial class Basarilar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Firma { get; set; }
        public string Tarih { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}