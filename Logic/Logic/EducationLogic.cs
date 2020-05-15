using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class EducationLogic : IDatabaseFunctions<Egitim, Egitim>
    {
        public bool Add(Egitim model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    model.Aktif = true;
                    model.EklemeTarihi = DateTime.Now;
                    db.Egitim.Add(model);
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
                var education = db.Egitim.Find(id);
                if (education != null)
                {
                    education.Aktif = false;
                    education.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Egitim GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Egitim.Find(id);
        }

        public List<Egitim> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Egitim.Where(x => x.Aktif).ToList();
        }

        public bool Update(Egitim model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var education = db.Egitim.Find(model.Id);
                    if (education != null)
                    {
                        education.DegisimTarihi = DateTime.Now;
                        education.Aktif = true;
                        education.OkulAdi = model.OkulAdi;
                        education.BaslangicTarihi = model.BaslangicTarihi;
                        education.BitisTarihi = model.BitisTarihi;
                        education.EgitimSeviyesi = model.EgitimSeviyesi;
                        education.MezuniyetDerecesi = model.MezuniyetDerecesi;
                        education.NotSistemi = model.NotSistemi;
                        education.Fakulte = model.Fakulte;
                        education.Bolum = model.Bolum;
                        education.EgitimDili = model.EgitimDili;
                        education.EkAciklama = model.EkAciklama;
                        education.SehirId = model.SehirId;
                        education.IlceId = model.IlceId;
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}