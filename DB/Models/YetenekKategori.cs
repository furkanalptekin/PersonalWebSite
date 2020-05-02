using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class YetenekKategori
    {
        public YetenekKategori()
        {
            Yetenekler = new HashSet<Yetenekler>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }

        public virtual ICollection<Yetenekler> Yetenekler { get; set; }
    }
}