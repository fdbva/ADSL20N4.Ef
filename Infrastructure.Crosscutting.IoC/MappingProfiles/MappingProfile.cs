using Application.ViewModels;
using AutoMapper;
using Domain.Model.Models;

namespace Infrastructure.Crosscutting.IoC.MappingProfiles
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
