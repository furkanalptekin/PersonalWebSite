using AutoMapper;
using Logic.Enums;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logic.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult UpdateDbExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, TEntity entity, Views view) where TEntity : class
        {
            controller.ViewBag.Update = true;
            if (controller.ModelState.IsValid)
            {
                controller.TempData["Alert"] = repository.Update(entity);
                controller.HttpContext.Session.Remove("UPDATEID");
                controller.ModelState.Clear();
                return controller.RedirectToAction(view.ToString());
            }
            return controller.View(view.ToString());
        }

        public static IActionResult UpdateExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, int? id, Views view) where TEntity : class
        {
            controller.ViewBag.Update = true;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                controller.HttpContext.Session.SetInt32("UPDATEID", (int)model.GetType().GetProperty("Id").GetValue(model));
                return controller.View(view.ToString(), model);
            }
            return controller.NotFound();
        }

        public static IActionResult UpdateExtensionMapper<TEntity, TMapDestination>(this Controller controller, IRepository<TEntity> repository, IMapper mapper, int? id, Views view) 
            where TEntity : class
            where TMapDestination : class
        {
            controller.ViewBag.Update = true;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                controller.HttpContext.Session.SetInt32("UPDATEID", (int)model.GetType().GetProperty("Id").GetValue(model));
                return controller.View(view.ToString(), mapper.Map<TMapDestination>(model));
            }
            return controller.NotFound();
        }

        public static IActionResult AddExtension(this Controller controller, Views view)
        {
            controller.ViewBag.Update = false;
            if (controller.TempData["Alert"] != null)
                controller.ViewBag.Alert = (bool)controller.TempData["Alert"];

            return controller.View(view.ToString());
        }

        public static IActionResult AddDbExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, TEntity entity, Views view) where TEntity : class
        {
            controller.ViewBag.Update = false;
            controller.ViewBag.SkillCategories = new DropDownLists().GetSkillCategories();
            if (controller.ModelState.IsValid)
            {
                controller.ViewBag.Alert = repository.Add(entity);
                controller.ModelState.Clear();
            }
            return controller.View(view.ToString());
        }

        public static IActionResult ShowExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, int? id, Views view) where TEntity : class
        {
            controller.ViewBag.Show = true;
            controller.ViewBag.Update = false;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                return controller.View(view.ToString(), model);
            }
            return controller.NotFound();
        }
    }
}