using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class SkillCategoriesLogic : IDatabaseFunctions<YetenekKategori, YetenekKategori>
    {
        public bool Add(YetenekKategori model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                model.EklemeTarihi = DateTime.Now;
                model.Aktif = true;
                db.YetenekKategori.Add(model);
                if (db.SaveChanges() > 0)
                    success = true;
            }
            return success;
        }

        public bool Delete(int? id)
        {
            bool success = false;
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var category = db.YetenekKategori.Find(id);
                if (category != null)
                {
                    category.Aktif = false;
                    category.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public YetenekKategori GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.YetenekKategori.Find(id);
        }

        public List<YetenekKategori> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.YetenekKategori.Where(x => x.Aktif).ToList();
        }

        public bool Update(YetenekKategori model)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var category = db.YetenekKategori.Find(model.Id);
                if (category != null)
                {
                    category.DegisimTarihi = DateTime.Now;
                    category.Aktif = true;
                    category.Adi = model.Adi;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}
