using DB.DataModels;
using DB.Models;
using DB.ViewModels;
using Logic.Enums;
using Logic.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Logic
{
    public class BlogLogic : IDatabaseFunctions<BlogViewModel, Blog>
    {
        public bool Add(BlogViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var file = Base64Processing.ImageToBase64(model.File);
                    if (file != null)
                    {
                        var blog = model.Blog;
                        blog.Aktif = true;
                        blog.EklemeTarihi = DateTime.Now;
                        blog.Fotograf = file;
                        db.Blog.Add(blog);
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
                var blog = db.Blog.Find(id);
                if (blog != null)
                {
                    blog.Aktif = false;
                    blog.DegisimTarihi = DateTime.Now;
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public Blog GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Blog.Find(id);
        }
        public BlogViewModel GetFromIdDecode(int? id)
        {
            BlogViewModel model = new BlogViewModel();
            using (PersonalWebSiteContext db = new PersonalWebSiteContext())
            {
                var blog = db.Blog.Find(id);
                if (blog != null)
                {
                    model = new BlogViewModel() { Blog = blog };
                    model.Blog.Detay = new HtmlString(WebUtility.HtmlDecode(model.Blog.Detay)).Value;
                }
            }
            return model;
        }

        public List<Blog> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Blog.Where(x => x.Aktif).ToList();
        }

        public List<BlogDataModel> GetDataModelList()
        {
            List<BlogDataModel> list = new List<BlogDataModel>();
            foreach (var item in GetList())
            {
                var file = item.Fotograf.Split('|');
                list.Add(new BlogDataModel()
                {
                    Id = item.Id,
                    Baslik = item.Baslik,
                    GosterimBaslangicTarihi = item.GosterimBaslangicTarihi,
                    GosterimBitisTarihi = item.GosterimBitisTarihi,
                    EklemeTarihi = item.EklemeTarihi,
                    DegisimTarihi = item.DegisimTarihi,
                    IconExt = file?[(int)FileHelper.FileExt],
                    Icon = file?[(int)FileHelper.B64String]
                });
            }
            return list;
        }

        public bool Update(BlogViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using (PersonalWebSiteContext db = new PersonalWebSiteContext())
                {
                    var blog = db.Blog.Find(model.Blog.Id);
                    if (blog != null)
                    {
                        blog.Aktif = true;
                        blog.DegisimTarihi = DateTime.Now;
                        blog.Baslik = model.Blog.Baslik;
                        blog.Detay = model.Blog.Detay;
                        blog.Ozet = model.Blog.Ozet;
                        blog.GosterimBaslangicTarihi = model.Blog.GosterimBaslangicTarihi;
                        blog.GosterimBitisTarihi = model.Blog.GosterimBitisTarihi;
                        if (model.File != null)
                            blog.Fotograf = Base64Processing.ImageToBase64(model.File);

                        if (db.SaveChanges() > 0)
                            success = true;
                    }
                }
            }
            return success;
        }
    }
}