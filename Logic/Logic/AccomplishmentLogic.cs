using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class AccomplishmentLogic : IDatabaseFunctions<Basarilar, Basarilar>
    {
        public bool Add(Basarilar model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    model.Aktif = true;
                    model.EklemeTarihi = DateTime.Now;
                    db.Basarilar.Add(model);
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
                var accomplishment = db.Basarilar.Find(id);
                if (accomplishment != null)
                {
                    accomplishment.Aktif = false;
                    accomplishment.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Basarilar GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Basarilar.Find(id);
        }

        public List<Basarilar> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Basarilar.Where(x => x.Aktif).ToList();
        }

        public bool Update(Basarilar model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var accomplishment = db.Basarilar.Find(model.Id);
                    if (accomplishment != null)
                    {
                        accomplishment.DegisimTarihi = DateTime.Now;
                        accomplishment.Aktif = true;
                        accomplishment.Adi = model.Adi;
                        accomplishment.Aciklama = model.Aciklama;
                        accomplishment.Firma = model.Firma;
                        accomplishment.Tarih = model.Tarih;
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}
