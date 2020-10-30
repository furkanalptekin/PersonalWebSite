using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Logic.Extensions
{
    public static class DBContextExtensions
    {
        /// <summary>
        /// Entity veritabanına kayıt eder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns>(<see cref="int"/>) İşlem başarılı ise 0'dan büyük, başarısız ise -1 döner.</returns>
        public static int AddEntity<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            if (entity == null)
                return -1;

            context.Add(entity);
            return context.SaveChanges();
        }

        /// <summary>
        /// Veritabanında bulunan nesneyi parametredeki nesneye göre <see cref="System.Reflection"/> yardımı ile update eder.
        /// Update etmek istemediğimiz değişkenleri <paramref name="propertiesToIgnore"/> nesnesi ile ayarlayabiliriz.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <param name="propertiesToIgnore"></param>
        /// <returns>(<see cref="int"/>) İşlem başarılı ise 0'dan büyük, başarısız ise -1 döner.</returns>
        public static int UpdateEntity<TEntity>(this DbContext context, TEntity entity, params string[] propertiesToIgnore) where TEntity : class
        {
            if (entity == null)
                return -1;

            var dbEntity = context.Set<TEntity>().Find(entity.GetType().GetProperty("Id").GetValue(entity, null));
            if (dbEntity == null)
                return -1;

            foreach (var item in entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty))
            {
                if (!item.CanRead || !item.CanWrite || propertiesToIgnore.Contains(item.Name))
                    continue;

                item.SetValue(dbEntity, item.GetValue(entity, null), null);
            }

            return context.SaveChanges();
        }

        /// <summary>
        /// Verilen Id'ye göre veritabanından nesneyi siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="Id"></param>
        /// <returns>(<see cref="int"/>) İşlem başarılı ise 0'dan büyük, başarısız ise -1 döner.</returns>
        public static int RemoveEntity<TEntity>(this DbContext context, int? Id) where TEntity : class
        {
            if (Id == null)
                return -1;

            var dbEntity = context.Set<TEntity>().Find(Id);
            if (dbEntity == null)
                return -1;

            var property = dbEntity.GetType().GetProperty("Aktif");
            if (property == null)
                return -1;
            
            property.SetValue(dbEntity, false);
            return context.SaveChanges();
        }
    }
}