using AutoMapper;
using Livraria.Application.Services.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;

namespace Livraria.Application.Services
{
    public class UsuarioService : ServiceBase<UsuarioViewModel, Usuario>, IUsuarioService
    {
        public UsuarioService(IMapper mapper, IUsuarioRepository repository) : base(mapper, repository)
        {
        }
    }
}