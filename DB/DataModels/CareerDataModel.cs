using System;

namespace DB.DataModels
{
    public class CareerDataModel
    {
        public int Id { get; set; }
        public string Firma { get; set; }
        public string Icon { get; set; }
        public string IconExt { get; set; }
        public string Pozisyon { get; set; }
        public string Adres { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}