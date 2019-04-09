using AutoMapper;
using Livraria.Application.Services.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Business.Dto;
using Livraria.Domain.Business.Interfaces;

namespace Livraria.Application.Services
{
    public class VinculacaoAutorLivroService : IVinculacaoAutorLivroService
    {
        private readonly IVinculacaoAutorNoLivroBusiness _vinculacaoAutorNoLivroBusiness;

        private readonly IMapper _mapper;

        public VinculacaoAutorLivroService(IVinculacaoAutorNoLivroBusiness vinculacaoAutorNoLivroBusiness,
            IMapper mapper)
        {
            _vinculacaoAutorNoLivroBusiness = vinculacaoAutorNoLivroBusiness;
            _mapper = mapper;
        }

        public LivroViewModel VincularAutorNoLivro(VinculacaoAutorLivroViewModel vinculacaoAutorLivro)
        {
            var vinculacaoAutorLivroDto = _mapper.Map<VinculacaoAutorLivroDto>(vinculacaoAutorLivro);

            var livro = _vinculacaoAutorNoLivroBusiness.VincularAutorNoLivro(vinculacaoAutorLivroDto);  
            
            return _mapper.Map<LivroViewModel>(livro);
        }
    }
}
