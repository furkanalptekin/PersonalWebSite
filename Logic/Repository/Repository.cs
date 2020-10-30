using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Logic.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PersonalWebSiteContext _context;

        public Repository()
        {
            _context = new PersonalWebSiteContext();
            //_context = RepositorySingleton.GetInstance();
        }

        public virtual bool Add(TEntity model, params object[] parameters)
        {
            return _context.AddEntity(model) > 0;
        }

        public virtual IList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetFromId(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual bool Remove(int? id)
        {
            return _context.RemoveEntity<TEntity>(id) > 0;
        }

        public virtual bool Update(TEntity model)
        {
            return _context.UpdateEntity(model) > 0;
        }

        public virtual IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }
    }
}