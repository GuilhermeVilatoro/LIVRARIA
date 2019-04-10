using Microsoft.AspNetCore.Mvc;
using Livraria.Application.ViewModels;
using Livraria.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base()
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult GetUsuarioViewModel()
        {
            return Response(_usuarioService.GetAll());
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult GetUsuarioViewModel(int id)
        {
            var viewModel = _usuarioService.GetById(id);

            return Response(viewModel);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult PutUsuarioViewModel([FromBody]UsuarioViewModel UsuarioViemModel)
        {
            if (!ModelState.IsValid)
                return Response(UsuarioViemModel);

            _usuarioService.Update(UsuarioViemModel);

            return Response(UsuarioViemModel);
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult PostUsuarioViewModel(UsuarioViewModel UsuarioViemModel)
        {
            if (!ModelState.IsValid)
                return Response(UsuarioViemModel);

            _usuarioService.Add(UsuarioViemModel);

            return Response(UsuarioViemModel);
        }       
    }
}