using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ForeignLanguagesLogic : IDatabaseFunctions<YabanciDil, YabanciDil>
    {
        public bool Add(YabanciDil model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    model.EklemeTarihi = DateTime.Now;
                    model.Aktif = true;
                    db.YabanciDil.Add(model);
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public bool Delete(int? id)
        {
            bool success = false;
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var lang = db.YabanciDil.Find(id);
                if (lang != null)
                {
                    lang.Aktif = false;
                    lang.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public YabanciDil GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.YabanciDil.Find(id);
        }

        public List<YabanciDil> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.YabanciDil.Where(x => x.Aktif).ToList();
        }

        public bool Update(YabanciDil model)
        {
            bool success = false;
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var lang = db.YabanciDil.Find(model.Id);
                if (lang != null)
                {
                    lang.DegisimTarihi = DateTime.Now;
                    lang.Aktif = true;
                    lang.Adi = model.Adi;
                    lang.Seviyesi = model.Seviyesi;
                    lang.OkumaSeviyesi = model.OkumaSeviyesi;
                    lang.YazmaSeviyesi = model.YazmaSeviyesi;
                    lang.KonusmaSeviyesi = model.KonusmaSeviyesi;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}