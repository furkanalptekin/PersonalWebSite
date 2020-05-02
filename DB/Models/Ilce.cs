using System.Collections.Generic;

namespace DB.Models
{
    public partial class Ilce
    {
        public Ilce()
        {
            Egitim = new HashSet<Egitim>();
            KisiDogumIlce = new HashSet<Kisi>();
            KisiKonumIlce = new HashSet<Kisi>();
        }

        public int Id { get; set; }
        public int? SehirId { get; set; }
        public string IlceAdi { get; set; }

        public virtual ICollection<Egitim> Egitim { get; set; }
        public virtual ICollection<Kisi> KisiDogumIlce { get; set; }
        public virtual ICollection<Kisi> KisiKonumIlce { get; set; }
    }
}