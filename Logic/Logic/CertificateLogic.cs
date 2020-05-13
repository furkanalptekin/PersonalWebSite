using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class CertificateLogic : IDatabaseFunctions<Sertifikalar, Sertifikalar>
    {
        public bool Add(Sertifikalar model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    model.Aktif = true;
                    model.EklemeTarihi = DateTime.Now;
                    db.Sertifikalar.Add(model);
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
                var cert = db.Sertifikalar.Find(id);
                if (cert != null)
                {
                    cert.Aktif = false;
                    cert.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Sertifikalar GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Sertifikalar.Find(id);
        }

        public List<Sertifikalar> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Sertifikalar.Where(x => x.Aktif).ToList();
        }

        public bool Update(Sertifikalar model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var cert = db.Sertifikalar.Find(model.Id);
                    if (cert != null)
                    {
                        cert.DegisimTarihi = DateTime.Now;
                        cert.Aktif = true;
                        cert.Adi = model.Adi;
                        cert.Brans = model.Brans;
                        cert.Firma = model.Firma;
                        cert.Tarih = model.Tarih;
                        cert.GecerlilikSuresi = model.GecerlilikSuresi;
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}
