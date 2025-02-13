﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Egitim
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Okul Adı Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string OkulAdi { get; set; }
        [Required(ErrorMessage = "Eğitim Seviyesi Boş Geçilemez."), MaxLength(50, ErrorMessage = "Maksimum 50 Karakter Olabilir.")]
        public string EgitimSeviyesi { get; set; }
        public string MezuniyetDerecesi { get; set; }
        public int? NotSistemi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Fakulte { get; set; }
        public string Bolum { get; set; }
        public string EgitimDili { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string EkAciklama { get; set; }
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }
        public bool Aktif { get; set; } = true;

        public virtual Ilce Ilce { get; set; }
        public virtual Sehir Sehir { get; set; }
    }
}