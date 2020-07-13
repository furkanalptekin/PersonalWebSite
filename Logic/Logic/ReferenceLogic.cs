using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ReferenceLogic : IDatabaseFunctions<Referanslar, Referanslar>
    {
        public bool Add(Referanslar model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                model.Aktif = true;
                model.EklemeTarihi = DateTime.Now;
                db.Referanslar.Add(model);
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
                var references = db.Referanslar.Find(id);
                if (references != null)
                {
                    references.Aktif = false;
                    references.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Referanslar GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Referanslar.Find(id);
        }

        public List<Referanslar> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Referanslar.Where(x => x.Aktif).ToList();
        }

        public bool Update(Referanslar model)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var references = db.Referanslar.Find(model.Id);
                if (references != null)
                {
                    references.DegisimTarihi = DateTime.Now;
                    references.Aktif = true;
                    references.Adi = model.Adi;
                    references.Firma = model.Firma;
                    references.Telefon = model.Telefon;
                    references.Eposta = model.Eposta;
                    references.Meslek = model.Meslek;
                    references.Pozisyon = model.Pozisyon;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}
