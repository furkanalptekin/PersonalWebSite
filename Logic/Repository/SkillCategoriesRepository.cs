using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class SkillCategoriesRepository : Repository<YetenekKategori>, ISkillCategoriesRepository
    {
        public override bool Update(YetenekKategori model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}