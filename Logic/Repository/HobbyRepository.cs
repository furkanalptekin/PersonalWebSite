using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class HobbyRepository : Repository<Hobiler>, IHobbyRepository
    {
        public override bool Add(Hobiler model, params object[] parameters)
        {
            var entity = model as HobbyViewModel;
            if (entity.IconFile != null)
                entity.Ikon = entity.IconFile.ImageToBase64();

            return _context.AddEntity(entity) > 0;
        }

        public override bool Update(Hobiler model)
        {
            var entity = model as HobbyViewModel;
            if (entity.IconFile != null)
            {
                model.Ikon = entity.IconFile.ImageToBase64();
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(entity.IconFile)) > 0;
            }
            else
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(model.Ikon), nameof(entity.IconFile)) > 0;
        }
    }
}