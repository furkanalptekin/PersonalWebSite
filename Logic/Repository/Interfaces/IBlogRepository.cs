using DB.Models;

namespace Logic.Repository.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        public Blog GetFromIdAndDecode(int? id);
    }
}