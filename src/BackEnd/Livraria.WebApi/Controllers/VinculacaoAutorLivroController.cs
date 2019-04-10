using Microsoft.AspNetCore.Mvc;
using Livraria.Application.Services.Interfaces;
using Livraria.Application.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class VinculacaoAutorLivroController : ApiController
    {
        private readonly IVinculacaoAutorLivroService _vinculacaoAutorLivroService;

        public VinculacaoAutorLivroController(IVinculacaoAutorLivroService vinculacaoAutorLivroService) : base()
        {
            _vinculacaoAutorLivroService = vinculacaoAutorLivroService;
        }

        // POST: api/VinculacaoAutorLivro
        [HttpPost]
        public IActionResult PostVinculacaoAutorLivroViewModel(VinculacaoAutorLivroViewModel vinculacaoAutorLivroViewModel)
        {
            if (!ModelState.IsValid)
                return Response(vinculacaoAutorLivroViewModel);

            try
            {
                var livroViewModel = _vinculacaoAutorLivroService.VincularAutorNoLivro(vinculacaoAutorLivroViewModel);
                return Response(livroViewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao vincular o autor no livro: {ex.Message}");
            }          
        }        
    }
}