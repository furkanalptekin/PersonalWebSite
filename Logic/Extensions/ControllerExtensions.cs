using AutoMapper;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logic.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Update <see cref="HttpPostAttribute"/> için extension methodu. Model geçerli ise veritabanını update eder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="controller"></param>
        /// <param name="repository"></param>
        /// <param name="entity"></param>
        /// <param name="view"></param>
        /// <returns>Parametre ile verilen View'e model geçersiz ise <see cref="IActionResult"/> olarak, 
        /// geçerli ise update işleminden sonra <see cref="RedirectToActionResult"/> olarak geri dönüş yapar.</returns>
        public static IActionResult UpdateDbExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, TEntity entity, string view) where TEntity : class
        {
            controller.ViewBag.Update = true;
            if (controller.ModelState.IsValid)
            {
                controller.TempData["Alert"] = repository.Update(entity);
                controller.HttpContext.Session.Remove("UPDATEID");
                controller.ModelState.Clear();
                return controller.RedirectToAction(view);
            }
            return controller.View(view);
        }

        /// <summary>
        /// Update <see cref="HttpGetAttribute"/> için extension methodu. Id'ye göre veritabanından modeli getirir. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="controller"></param>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <param name="view"></param>
        /// <returns>Parametre ile verilen View'i <see cref="IActionResult"/> olarak, Model bulunamaz ise <see cref="NotFoundResult"/> geri döner.</returns>
        public static IActionResult UpdateExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, int? id, string view) where TEntity : class
        {
            controller.ViewBag.Update = true;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                controller.HttpContext.Session.SetInt32("UPDATEID", (int)model.GetType().GetProperty("Id").GetValue(model));
                return controller.View(view, model);
            }
            return controller.NotFound();
        }

        /// <summary>
        /// Update <see cref="HttpGetAttribute"/> için extension methodu. Id'ye göre veritabanından modeli getirir. 
        /// Modeli <see cref="IMapper"/> ile Dto'ya çevirir.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TMapDestination"></typeparam>
        /// <param name="controller"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="id"></param>
        /// <param name="view"></param>
        /// <returns>Parametre ile verilen View'i <see cref="IActionResult"/> olarak, Model bulunamaz ise <see cref="NotFoundResult"/> geri döner.</returns>
        public static IActionResult UpdateExtensionMapper<TEntity, TMapDestination>(this Controller controller, IRepository<TEntity> repository, IMapper mapper, int? id, string view) 
            where TEntity : class
            where TMapDestination : class
        {
            controller.ViewBag.Update = true;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                controller.HttpContext.Session.SetInt32("UPDATEID", (int)model.GetType().GetProperty("Id").GetValue(model));
                return controller.View(view, mapper.Map<TMapDestination>(model));
            }
            return controller.NotFound();
        }

        /// <summary>
        /// Add <see cref="HttpGetAttribute"/> için extension methodu.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="view"></param>
        /// <returns>Parametre ile verilen View'i <see cref="IActionResult"/> olarak geri döner.</returns>
        public static IActionResult AddExtension(this Controller controller, string view)
        {
            controller.ViewBag.Update = false;
            if (controller.TempData["Alert"] != null)
                controller.ViewBag.Alert = (bool)controller.TempData["Alert"];

            return controller.View(view);
        }

        /// <summary>
        /// Add <see cref="HttpPostAttribute"/> için extension methodu. 
        /// Model geçerli ise veritabanına ekler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="controller"></param>
        /// <param name="repository"></param>
        /// <param name="entity"></param>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        /// <returns>Parametre ile verilen View'i <see cref="IActionResult"/> olarak geri döner.</returns>
        public static IActionResult AddDbExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, TEntity entity, string view, params object[] parameters) where TEntity : class
        {
            controller.ViewBag.Update = false;
            if (controller.ModelState.IsValid)
            {
                controller.ViewBag.Alert = repository.Add(entity, parameters);
                controller.ModelState.Clear();
            }
            return controller.View(view);
        }

        /// <summary>
        /// Id'ye göre veritabanından nesneyi geri döner. 
        /// Veritabanında nesne bulunamaz ise <see cref="NotFoundResult"/> geriye döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="controller"></param>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <param name="view"></param>
        /// <returns>Parametre ile verilen View'i model veritabanında mecvut ise <see cref="IActionResult"/>, 
        /// değil ise <see cref="NotFoundResult"/> olarak geri döner.</returns>
        public static IActionResult ShowExtension<TEntity>(this Controller controller, IRepository<TEntity> repository, int? id, string view) where TEntity : class
        {
            controller.ViewBag.Show = true;
            controller.ViewBag.Update = false;
            var model = repository.GetFromId(id);
            if (model != null)
            {
                return controller.View(view, model);
            }
            return controller.NotFound();
        }
    }
}