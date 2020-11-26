using AutoMapper;
using Domain.Model.Models;
using WebApi.ViewModels;

namespace WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorRequest, AutorEntity>().ReverseMap();
            CreateMap<LivroRequest, LivroEntity>().ReverseMap();
            CreateMap<LivroAutorCreateRequest, LivroAutorCreateModel>().ReverseMap();
        }
    }
}
