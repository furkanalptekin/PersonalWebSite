using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IDatabaseFunctions<T, K> where T : class
                                              where K : class
    {
        public bool Add(T model, params object[] parameters);
        public bool Update(T model);
        public bool Delete(int? id);
        public K GetFromId(int? id);
        public List<K> GetList();
    }
}