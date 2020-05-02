using System.Collections.Generic;

namespace DB.Models
{
    public partial class Sehir
    {
        public Sehir()
        {
            Egitim = new HashSet<Egitim>();
            KisiDogumSehir = new HashSet<Kisi>();
            KisiKonumSehir = new HashSet<Kisi>();
        }

        public int Id { get; set; }
        public string SehirAdi { get; set; }

        public virtual ICollection<Egitim> Egitim { get; set; }
        public virtual ICollection<Kisi> KisiDogumSehir { get; set; }
        public virtual ICollection<Kisi> KisiKonumSehir { get; set; }
    }
}