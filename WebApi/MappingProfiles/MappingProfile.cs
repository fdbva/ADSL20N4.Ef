using AutoMapper;
using Domain.Model.Models;
using WebApi.ViewModels;

namespace WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorViewModel, AutorEntity>().ReverseMap();
            CreateMap<LivroViewModel, LivroEntity>().ReverseMap();
        }
    }
}
