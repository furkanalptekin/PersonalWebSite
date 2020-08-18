using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class YetenekKategori
    {
        public YetenekKategori()
        {
            Yetenekler = new HashSet<Yetenekler>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Yetenek Adı Boş Geçilemez."), MaxLength(255, ErrorMessage = "Maksimum 255 Karakter Olabilir.")]
        public string Adi { get; set; }
        public bool Aktif { get; set; } = true;
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? DegisimTarihi { get; set; }

        [JsonIgnore]
        public virtual ICollection<Yetenekler> Yetenekler { get; set; }
    }
}