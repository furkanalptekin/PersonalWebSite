using System;

namespace DB.DataModels
{
    public class HobbyDataModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Icon { get; set; }
        public string IconExt { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
    }
}