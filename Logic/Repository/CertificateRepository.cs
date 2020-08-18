using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class CertificateRepository : Repository<Sertifikalar>, ICertificateRepository
    {
        public override bool Update(Sertifikalar model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}