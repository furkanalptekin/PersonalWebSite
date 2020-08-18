using AutoMapper;
using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository.Interfaces;
using System.Linq;

namespace Logic.Repository
{
    public class PersonRepository : Repository<Kisi>, IPersonRepository
    {
        public override bool Add(Kisi model, params object[] parameters)
        {
            var entity = model as PersonViewModel;
            if (entity.File != null)
                entity.Fotograf = entity.File.ImageToBase64();

            if (entity.Ehliyetler != null && entity.Ehliyetler.Count != 0)
                entity.Ehliyet = string.Join(",", entity.Ehliyetler);

            return _context.AddEntity(entity) > 0;
        }

        public Kisi GetPerson()
        {
            return _context.Kisi.AsEnumerable().LastOrDefault();
        }

        public PersonViewModel GetPersonViewModel(IMapper mapper)
        {
            var person = GetPerson();
            var personViewModel = mapper.Map<PersonViewModel>(person);
            personViewModel.Ehliyetler = person.Ehliyet.Split(',').ToList();
            return personViewModel;
        }

        public override bool Update(Kisi model)
        {
            var entity = model as PersonViewModel;

            if (entity.Ehliyetler != null && entity.Ehliyetler.Count != 0)
                entity.Ehliyet = string.Join(",", entity.Ehliyetler);

            if (entity.File != null)
            {
                model.Fotograf = entity.File.ImageToBase64();
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(entity.File), nameof(entity.Ehliyetler)) > 0;
            }
            else
                return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi), nameof(model.Fotograf), nameof(entity.File), nameof(entity.Ehliyetler)) > 0;
        }
    }
}