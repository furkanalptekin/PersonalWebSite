using System;

namespace DB.DataModels
{
    public class BlogDataModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icon { get; set; }
        public string IconExt { get; set; }
        public DateTime GosterimBaslangicTarihi { get; set; }
        public DateTime? GosterimBitisTarihi { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}