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
    public class CareerLogic : IDatabaseFunctions<CareerViewModel, MeslekiDeneyim>
    {
        public bool Add(CareerViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var file = model.Icon.ImageToBase64();
                if (file != null)
                {
                    var career = model.MeslekiDeneyim;
                    career.Aktif = true;
                    career.EklemeTarihi = DateTime.Now;
                    career.FirmaIcon = file;
                    db.MeslekiDeneyim.Add(career);
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
                var career = db.MeslekiDeneyim.Find(id);
                if (career != null)
                {
                    career.DegisimTarihi = DateTime.Now;
                    career.Aktif = false;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public MeslekiDeneyim GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.MeslekiDeneyim.Find(id);
        }

        public List<MeslekiDeneyim> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.MeslekiDeneyim.Where(x => x.Aktif).ToList();
        }

        public List<CareerDataModel> GetDataModelList()
        {
            List<CareerDataModel> list = new List<CareerDataModel>();
            foreach (var item in GetList())
            {
                var file = item.FirmaIcon.Split('|');
                list.Add(new CareerDataModel()
                {
                    Id = item.Id,
                    Pozisyon = item.Pozisyon,
                    Adres = item.Adres,
                    BaslangicTarihi = item.BaslangicTarih,
                    BitisTarihi = item.BitisTarih,
                    DegisimTarihi = item.DegisimTarihi,
                    EklemeTarihi = item.EklemeTarihi,
                    Firma = item.Firma,
                    IconExt = file?[(int)FileHelper.FileExt],
                    Icon = file?[(int)FileHelper.B64String]
                });
            }
            return list;
        }

        public bool Update(CareerViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var career = db.MeslekiDeneyim.Find(model.MeslekiDeneyim.Id);
                if (career != null)
                {
                    career.Aktif = true;
                    career.DegisimTarihi = DateTime.Now;
                    career.Firma = model.MeslekiDeneyim.Firma;
                    career.BaslangicTarih = model.MeslekiDeneyim.BaslangicTarih;
                    career.BitisTarih = model.MeslekiDeneyim.BitisTarih;
                    career.Pozisyon = model.MeslekiDeneyim.Pozisyon;
                    career.Adres = model.MeslekiDeneyim.Adres;
                    if (model.Icon != null)
                        career.FirmaIcon = model.Icon.ImageToBase64();

                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }
    }
}