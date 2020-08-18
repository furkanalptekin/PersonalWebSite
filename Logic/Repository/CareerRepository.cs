using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class CareerRepository : Repository<MeslekiDeneyim>, ICareerRepository
    {
        public override bool Add(MeslekiDeneyim model, params object[] parameters)
        {
            var entity = model as CareerViewModel;
            if (entity.IconFile != null)
                entity.FirmaIcon = entity.IconFile.ImageToBase64();

            return _context.AddEntity(entity) > 0;
        }

        public override bool Update(MeslekiDeneyim model)
        {
            var entity = model as CareerViewModel;
            if (entity.IconFile != null)
            {
                model.FirmaIcon = entity.IconFile.ImageToBase64();
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(entity.IconFile)) > 0;
            }
            else
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(model.FirmaIcon), nameof(entity.IconFile)) > 0;
        }
    }
}