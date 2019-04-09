using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Business.Dto;

namespace Livraria.Application.AutoMapper
{
    public class ViewModelToBusinessDtoMappingProfile : Profile
    {
        public ViewModelToBusinessDtoMappingProfile()
        {
            CreateMap<VinculacaoAutorLivroViewModel, VinculacaoAutorLivroDto>();                                
        }
    }
}