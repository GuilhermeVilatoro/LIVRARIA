using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;

namespace Livraria.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Livro, LivroViewModel>();                                 
        }
    }
}