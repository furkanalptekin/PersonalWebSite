using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Logic.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public bool Add(TEntity model, params object[] parameters);
        public bool Remove(int? id);
        public bool Update(TEntity model);
        public TEntity GetFromId(int? id);
        public IList<TEntity> GetAll();
        public IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}