using DB.DataModels;
using DB.Models;
using DB.ViewModels;
using Logic.Enums;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class SocialMediaLogic : IDatabaseFunctions<SocialMediaViewModel, SosyalMedya>
    {
        public bool Add(SocialMediaViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var file = Base64Processing.ImageToBase64(model.Icon);
                    if (file != null)
                    {
                        var socialMedia = model.SosyalMedya;
                        socialMedia.Aktif = true;
                        socialMedia.EklemeTarihi = DateTime.Now;
                        socialMedia.Ikon = file;
                        db.SosyalMedya.Add(socialMedia);
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }

        public bool Delete(int? id)
        {
            bool success = false;
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var socialMedia = db.SosyalMedya.Find(id);
                if (socialMedia != null)
                {
                    socialMedia.Aktif = false;
                    socialMedia.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public SosyalMedya GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.SosyalMedya.Find(id);
        }

        public List<SosyalMedya> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.SosyalMedya.Where(x => x.Aktif).ToList();
        }

        public List<SocialMediaDataModel> GetDataModelList()
        {
            List<SocialMediaDataModel> list = new List<SocialMediaDataModel>();
            foreach (var item in GetList())
            {
                var file = item.Ikon.Split('|');
                list.Add(new SocialMediaDataModel()
                {
                    Id = item.Id,
                    SosyalMedyaAdi = item.SosyalMedyaAdi,
                    Adres = item.Adres,
                    EklemeTarihi = item.EklemeTarihi,
                    DegisimTarihi = item.DegisimTarihi,
                    IconExt = file?[(int)FileHelper.FileExt],
                    Icon = file?[(int)FileHelper.B64String]
                });
            }
            return list;
        }

        public bool Update(SocialMediaViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var socialMedia = db.SosyalMedya.Find(model.SosyalMedya.Id);
                    if (socialMedia != null)
                    {
                        socialMedia.Aktif = true;
                        socialMedia.DegisimTarihi = DateTime.Now;
                        socialMedia.SosyalMedyaAdi = model.SosyalMedya.SosyalMedyaAdi;
                        socialMedia.Adres = model.SosyalMedya.Adres;
                        if (model.Icon != null)
                            socialMedia.Ikon = Base64Processing.ImageToBase64(model.Icon);

                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}