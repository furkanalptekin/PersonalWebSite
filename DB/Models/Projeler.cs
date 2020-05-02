using System;

namespace DB.Models
{
    public partial class Projeler
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Link { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string KullanilanDiller { get; set; }
        public string Aciklama { get; set; }
        public string YapilisNedeni { get; set; }
        public string Kategori { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}