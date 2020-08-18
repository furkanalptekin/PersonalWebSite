using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class LanguageRepository : Repository<YabanciDil>, ILanguageRepository
    {
        public override bool Update(YabanciDil model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}