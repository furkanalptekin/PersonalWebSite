using System;

namespace DB.DataModels
{
    public class SocialMediaDataModel
    {
        public int Id { get; set; }
        public string SosyalMedyaAdi { get; set; }
        public string Adres { get; set; }
        public string Icon { get; set; }
        public string IconExt { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}