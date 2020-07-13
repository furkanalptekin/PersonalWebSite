using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ProjectLogic : IDatabaseFunctions<Projeler, Projeler>
    {
        public bool Add(Projeler model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                model.Aktif = true;
                model.EklemeTarihi = DateTime.Now;
                db.Projeler.Add(model);
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
                var projects = db.Projeler.Find(id);
                if (projects != null)
                {
                    projects.Aktif = false;
                    projects.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Projeler GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Projeler.Find(id);
        }

        public List<Projeler> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Projeler.Where(x => x.Aktif).ToList();
        }

        public bool Update(Projeler model)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var projects = db.Projeler.Find(model.Id);
                if (projects != null)
                {
                    projects.DegisimTarihi = DateTime.Now;
                    projects.Aktif = true;
                    projects.Adi = model.Adi;
                    projects.Link = model.Link;
                    projects.BaslangicTarihi = model.BaslangicTarihi;
                    projects.BitisTarihi = model.BitisTarihi;
                    projects.KullanilanDiller = model.KullanilanDiller;
                    projects.Aciklama = model.Aciklama;
                    projects.YapilisNedeni = model.YapilisNedeni;
                    projects.Kategori = model.Kategori;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}