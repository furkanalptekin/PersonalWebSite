using DB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class DropDownLists
    {
        public List<SelectListItem> GetSkillCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                foreach (var item in db.YetenekKategori.Where(x => x.Aktif))
                {
                    list.Add(new SelectListItem() { Text = item.Adi, Value = item.Id.ToString() });
                }
            }
            return list;
        }

        public List<SelectListItem> GetLanguageRating(bool A1)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (A1)
            {
                list.Add(new SelectListItem() { Text = "Seviye Seçiniz", Value = "0" });
                list.Add(new SelectListItem() { Text = "A1", Value = "A1" });
                list.Add(new SelectListItem() { Text = "A2", Value = "A2" });
                list.Add(new SelectListItem() { Text = "B1", Value = "B1" });
                list.Add(new SelectListItem() { Text = "B2", Value = "B2" });
                list.Add(new SelectListItem() { Text = "C1", Value = "C1" });
                list.Add(new SelectListItem() { Text = "C2", Value = "C2" });
            }
            else
            {
                list.Add(new SelectListItem() { Text = "Seviye Seçiniz", Value = "0" });
                list.Add(new SelectListItem() { Text = "Çok Kötü", Value = "Çok Kötü" });
                list.Add(new SelectListItem() { Text = "Kötü", Value = "Kötü" });
                list.Add(new SelectListItem() { Text = "Orta", Value = "Orta" });
                list.Add(new SelectListItem() { Text = "İyi", Value = "İyi" });
                list.Add(new SelectListItem() { Text = "Çok İyi", Value = "Çok İyi" });
            }
            return list;
        }

        public List<SelectListItem> GetCities()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Şehir Seçiniz.", Value = "0" }
            };
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                foreach (var item in db.Sehir.ToList())
                {
                    list.Add(new SelectListItem() { Text = item.SehirAdi, Value = item.Id.ToString() });
                }
            }
            return list;
        }

        public List<SelectListItem> GetDistricts(int SehirId, bool GetEmpty)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "İlçe Seçiniz.", Value = "0" }
            };
            if (!GetEmpty)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                foreach (var item in db.Ilce.Where(x => x.SehirId == SehirId).ToList())
                {
                    list.Add(new SelectListItem() { Text = item.IlceAdi, Value = item.Id.ToString() });
                }
            }
            return list;
        }

        public List<SelectListItem> GetEducationTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Seviye Seçiniz", Value = "0" },
                new SelectListItem() { Text = "İlkokul", Value = "İlkokul" },
                new SelectListItem() { Text = "İlk Öğretim", Value = "İlk Öğretim" },
                new SelectListItem() { Text = "Orta Okul", Value = "Orta Okul" },
                new SelectListItem() { Text = "Lise", Value = "Lise" },
                new SelectListItem() { Text = "Üniversite", Value = "Üniversite" },
                new SelectListItem() { Text = "Yüksek Lisans", Value = "Yüksek Lisans" },
                new SelectListItem() { Text = "Doktora", Value = "Doktora" }
            };
            return list;
        }
    }
}