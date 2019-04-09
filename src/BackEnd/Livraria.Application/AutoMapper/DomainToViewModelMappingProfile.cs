using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;

namespace Livraria.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AutorViewModel, Autor>();
            CreateMap<LivroViewModel, Livro>();                              
        }
    }
}