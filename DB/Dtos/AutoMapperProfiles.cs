using AutoMapper;
using DB.Models;
using DB.ViewModels;

namespace DB.Dtos
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region Sosyal Medya
            CreateMap<SosyalMedya, SocialMediaViewModel>();
            #endregion

            #region Yetenekler
            CreateMap<Yetenekler, SkillsDto>()
                .ForMember(
                dest => dest.KategoriAdi, 
                opt => opt.MapFrom(src => src.Kategori.Adi));
            #endregion

            #region Blog
            CreateMap<Blog, BlogDto>();
            CreateMap<Blog, BlogViewModel>();
            #endregion

            #region Kariyer
            CreateMap<MeslekiDeneyim, CareerViewModel>();
            #endregion

            #region CV
            CreateMap<Cv, CvDto>();
            CreateMap<Cv, CvViewModel>();
            #endregion

            #region Hobi
            CreateMap<Hobiler, HobbyViewModel>();
            #endregion

            #region Kisi
            CreateMap<Kisi, PersonViewModel>();
            #endregion
        }
    }
}