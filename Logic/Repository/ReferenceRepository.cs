using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class ReferenceRepository : Repository<Referanslar>, IReferenceRepository
    {
        public override bool Update(Referanslar model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}