using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class EducationRepository : Repository<Egitim>, IEducationRepository
    {
        public override bool Update(Egitim model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}