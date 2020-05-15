using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class AccountLogic : IDatabaseFunctions<Hesap, Hesap>
    {
        public bool Add(Hesap model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    model.Aktif = true;
                    model.EklemeTarihi = DateTime.Now;
                    model.Sifre = Sha256Helper.Hash(model.Sifre);
                    db.Hesap.Add(model);
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
                var acc = db.Hesap.Find(id);
                if (acc != null)
                {
                    acc.Aktif = false;
                    acc.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Hesap GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Hesap.Find(id);
        }

        public List<Hesap> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Hesap.Where(x => x.Aktif).ToList();
        }

        public bool Update(Hesap model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var acc = db.Hesap.Find(model.Id);
                    if (acc != null)
                    {
                        acc.DegisimTarihi = DateTime.Now;
                        acc.Aktif = true;
                        if (model.Sifre != null)
                            acc.Sifre = Sha256Helper.Hash(model.Sifre);
                        acc.AdSoyad = model.AdSoyad;
                        acc.KullaniciAdi = model.KullaniciAdi;
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}