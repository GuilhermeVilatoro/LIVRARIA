using Microsoft.AspNetCore.Mvc;
using Livraria.Application.ViewModels;
using Livraria.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class AutorController : ApiController
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService) : base()
        {
            _autorService = autorService;
        }

        // GET: api/Autor
        [HttpGet]
        public IActionResult GetAutorViewModel()
        {
            return Response(_autorService.GetAll());
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public IActionResult GetAutorViewModel(int id)
        {
            var viewModel = _autorService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public IActionResult PutAutorViewModel([FromBody]AutorViewModel autorViemModel)
        {
            if (!ModelState.IsValid)
                return Response(autorViemModel);

            _autorService.Update(autorViemModel);

            return Response(autorViemModel);
        }

        // POST: api/Autor
        [HttpPost]
        public IActionResult PostAutorViewModel(AutorViewModel autorViemModel)
        {
            if (!ModelState.IsValid)
                return Response(autorViemModel);

            _autorService.Add(autorViemModel);

            return Response(autorViemModel);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAutorViewModel(int id)
        {
            _autorService.Delete(id);

            return Response();
        }
    }
}