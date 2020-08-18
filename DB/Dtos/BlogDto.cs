using System;

namespace DB.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Fotograf { get; set; }
        public DateTime GosterimBaslangicTarihi { get; set; }
        public DateTime? GosterimBitisTarihi { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}