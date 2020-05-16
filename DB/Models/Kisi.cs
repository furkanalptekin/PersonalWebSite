using System;

namespace DB.Models
{
    public partial class Kisi
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string CepTelefonu { get; set; }
        public string SabitTelefonu { get; set; }
        public string Faks { get; set; }
        public bool? SigaraKullanımDurumu { get; set; }
        public bool? AlkolKullanımDurumu { get; set; }
        public bool? EngelDurumu { get; set; }
        public bool? SeyahatEngeliDurumu { get; set; }
        public string Ehliyet { get; set; }
        public string KanGrubu { get; set; }
        public string MedeniDurum { get; set; }
        public string Cinsiyet { get; set; }
        public string Fotograf { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string AskerlikDurumu { get; set; }
        public DateTime? TecilTarihi { get; set; }
        public string Meslek { get; set; }
        public int? DogumSehirId { get; set; }
        public int? DogumIlceId { get; set; }
        public int? KonumSehirId { get; set; }
        public int? KonumIlceId { get; set; }
        public string Uyruk { get; set; }
        public string IsAramaDurumu { get; set; }
        public string KariyerHedefi { get; set; }
        public string OnYazi { get; set; }
        public string UcretBeklentisi { get; set; }
        public string CalismakIstenilenSehir { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }

        public virtual Ilce DogumIlce { get; set; }
        public virtual Sehir DogumSehir { get; set; }
        public virtual Ilce KonumIlce { get; set; }
        public virtual Sehir KonumSehir { get; set; }
    }
}