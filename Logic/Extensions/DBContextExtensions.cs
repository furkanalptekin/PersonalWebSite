using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Logic.Extensions
{
    public static class DBContextExtensions
    {
        public static int AddEntity<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            if (entity == null)
                return -1;

            context.Add(entity);
            return context.SaveChanges();
        }

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