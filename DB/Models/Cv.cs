using System;

namespace DB.Models
{
    public partial class Cv
    {
        public int Id { get; set; }
        public string CvAdi { get; set; }
        public string B64 { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}