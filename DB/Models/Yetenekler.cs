using System;

namespace DB.Models
{
    public partial class Yetenekler
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int? BasariOrani { get; set; }
        public string RenkKodu { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public int? KategoriId { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }

        public virtual YetenekKategori Kategori { get; set; }
    }
}