using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Html;
using System.Net;

namespace Logic.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository 
    {
        public Blog GetFromIdAndDecode(int? id)
        {
            var blog = _context.Blog.Find(id);
            if (blog != null)
                blog.Detay = new HtmlString(WebUtility.HtmlDecode(blog.Detay)).Value;

            return blog;
        }

        public override bool Add(Blog model, params object[] parameters)
        {
            var entity = model as BlogViewModel;
            if (entity.FotoFile != null)
                entity.Fotograf = entity.FotoFile.ImageToBase64();

            return _context.AddEntity(entity) > 0;
        }
        public override bool Update(Blog model)
        {
            var entity = model as BlogViewModel;
            if (entity.FotoFile != null)
            {
                model.Fotograf = entity.FotoFile.ImageToBase64();
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(entity.FotoFile)) > 0;
            }
            else
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(model.Fotograf), nameof(entity.FotoFile)) > 0;
        }
    }
}