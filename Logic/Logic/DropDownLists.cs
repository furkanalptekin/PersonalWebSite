using DB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
