using DB.DataModels;
using DB.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class SkillsLogic : IDatabaseFunctions<Yetenekler, Yetenekler>
    {
        public bool Add(Yetenekler model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                model.EklemeTarihi = DateTime.Now;
                model.Aktif = true;
                db.Yetenekler.Add(model);
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
                var skill = db.Yetenekler.Find(id);
                if (skill != null)
                {
                    skill.Aktif = false;
                    skill.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Yetenekler GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Yetenekler.Find(id);
        }

        public List<Yetenekler> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Yetenekler.Where(x => x.Aktif).ToList();
        }

        public List<SkillsDataModel> GetDataModelList()
        {
            List<SkillsDataModel> list = new List<SkillsDataModel>();
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var categories = db.YetenekKategori.ToList();
                var skills = db.Yetenekler.Where(x => x.Aktif).ToList();
                foreach (var item in skills)
                {
                    list.Add(new SkillsDataModel()
                    {
                        Id = item.Id,
                        Adi = item.Adi,
                        Aktif = item.Aktif,
                        BasariOrani = item.BasariOrani,
                        RenkKodu = item.RenkKodu,
                        DegisimTarihi = item.DegisimTarihi,
                        EklemeTarihi = item.EklemeTarihi,
                        KategoriAdi = categories.Where(x => x.Id == item.KategoriId).FirstOrDefault().Adi
                    });
                }
            }
            return list;
        }

        public bool Update(Yetenekler model)
        {
            bool success = false;
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var skill = db.Yetenekler.Find(model.Id);
                if (skill != null)
                {
                    skill.DegisimTarihi = DateTime.Now;
                    skill.Aktif = true;
                    skill.Adi = model.Adi;
                    skill.RenkKodu = model.RenkKodu;
                    skill.BasariOrani = model.BasariOrani;
                    skill.KategoriId = model.KategoriId;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}