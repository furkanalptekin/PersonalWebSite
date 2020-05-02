using System;

namespace DB.Models
{
    public partial class YabanciDil
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Seviyesi { get; set; }
        public string OkumaSeviyesi { get; set; }
        public string YazmaSeviyesi { get; set; }
        public string KonusmaSeviyesi { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}