using DB.DataModels;
using DB.Models;
using DB.ViewModels;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class CvLogic : IDatabaseFunctions<CvFileModel, Cv>
    {
        public bool Add(CvFileModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                if (model.File != null)
                {
                    string b64 = model.File.PDFToBase64();
                    if (b64 != null)
                    {
                        model.Cv.B64 = b64;
                        model.Cv.EklemeTarihi = DateTime.Now;
                        model.Cv.Aktif = true;
                        db.Cv.Add(model.Cv);
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
                var cv = db.Cv.Where(x => x.Id == id).FirstOrDefault();
                cv.Aktif = false;
                cv.DegisimTarihi = DateTime.Now;
                if (db.SaveChanges() > 0)
                    success = true;
            }
            return success;
        }

        public Cv GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Cv.Find(id);
        }

        public List<Cv> GetList()
        {
            List<Cv> list = new List<Cv>();
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                list = db.Cv.Where(x => x.Aktif).ToList();
            }
            return list;
        }

        public bool Update(CvFileModel model)
        {
            throw new NotImplementedException();
        }

        public List<CvDataModel> ConvertToDataModel(List<Cv> list)
        {
            List<CvDataModel> cvs = new List<CvDataModel>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    cvs.Add(new CvDataModel()
                    {
                        Id = item.Id,
                        CvAdi = item.CvAdi,
                        EklemeTarihi = item.EklemeTarihi
                    });
                }
            }
            return cvs;
        }
    }
}