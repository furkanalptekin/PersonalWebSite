﻿using System;

namespace DB.Dtos
{
    public class SkillsDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int? BasariOrani { get; set; }
        public string RenkKodu { get; set; }
        public bool Aktif { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime? DegisimTarihi { get; set; }
        public string KategoriAdi { get; set; }
    }
}