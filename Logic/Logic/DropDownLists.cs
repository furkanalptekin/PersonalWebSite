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
    }
}