using AutoMapper;
using DB.Models;
using DB.ViewModels;

namespace Logic.Repository.Interfaces
{
    public interface IPersonRepository : IRepository<Kisi>
    {
        public Kisi GetPerson();
        public PersonViewModel GetPersonViewModel(IMapper mapper);
    }
}