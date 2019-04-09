using Microsoft.AspNetCore.Mvc;
using Livraria.Application.ViewModels;
using Livraria.Application.Services.Interfaces;
using System.Linq;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ApiController
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroApplicationService) : base()
        {
            _livroService = livroApplicationService;
        }

        // GET: api/Livro
        [HttpGet]
        public IActionResult GetLivroViewModel()
        {
            return Response( _livroService.GetAll().OrderBy(l => l.Titulo));
        }

        // GET: api/Livro/5
        [HttpGet("{id}")]
        public IActionResult GetLivroViewModel(int id)
        {
            var viewModel = _livroService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public IActionResult PutLivroViewModel([FromBody]LivroViewModel livroViemModel)
        {
            if (!ModelState.IsValid)
                return Response(livroViemModel);

            _livroService.Update(livroViemModel);

            return Response(livroViemModel);
        }

        // POST: api/Livro
        [HttpPost]
        public IActionResult PostLivroViewModel(LivroViewModel livroViemModel)
        {
            if (!ModelState.IsValid)
                return Response(livroViemModel);

            _livroService.Add(livroViemModel);

            return Response(livroViemModel);
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLivroViewModel(int id)
        {
            _livroService.Delete(id);

            return Response();
        }
    }
}
