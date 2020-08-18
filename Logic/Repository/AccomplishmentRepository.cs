using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class AccomplishmentRepository : Repository<Basarilar>, IAccomplishmentRepository
    {
        public override bool Update(Basarilar model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}