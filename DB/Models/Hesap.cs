using System;

namespace DB.Models
{
    public partial class Hesap
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}