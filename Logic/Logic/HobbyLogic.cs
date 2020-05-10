using DB.DataModels;
using DB.Models;
using DB.ViewModels;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class HobbyLogic : IDatabaseFunctions<HobbyViewModel, Hobiler>
    {
        public bool Add(HobbyViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var file = Base64Processing.ImageToBase64(model.Icon);
                    if (file != null)
                    {
                        var hobby = model.Hobiler;
                        hobby.Aktif = true;
                        hobby.EklemeTarihi = DateTime.Now;
                        hobby.Ikon = $"{file?[0]}|{file?[1]}";
                        db.Hobiler.Add(hobby);
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
                var hobby = db.Hobiler.Find(id);
                if (hobby != null)
                {
                    hobby.Aktif = false;
                    hobby.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Hobiler GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Hobiler.Find(id);
        }

        public List<Hobiler> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Hobiler.Where(x => x.Aktif).ToList();
        }

        public List<HobbyDataModel> GetDataModelList()
        {
            List<HobbyDataModel> list = new List<HobbyDataModel>();
            foreach (var item in GetList())
            {
                var file = item.Ikon.Split('|');
                list.Add(new HobbyDataModel() 
                {
                    Id = item.Id,
                    Adi = item.Adi,
                    EklemeTarihi = item.EklemeTarihi,
                    DegisimTarihi = item.DegisimTarihi,
                    IconExt = file?[0],
                    Icon = file?[1]
                });
            }
            return list;
        }

        public bool Update(HobbyViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var hobby = db.Hobiler.Find(model.Hobiler.Id);
                    if (hobby != null)
                    {
                        hobby.Aktif = true;
                        hobby.DegisimTarihi = DateTime.Now;
                        hobby.Adi = model.Hobiler.Adi;
                        if (model.Icon != null)
                        {
                            var file = Base64Processing.ImageToBase64(model.Icon);
                            hobby.Ikon = $"{file?[0]}|{file?[1]}";
                        }
                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}
