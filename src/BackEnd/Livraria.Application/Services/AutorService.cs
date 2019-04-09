using AutoMapper;
using Livraria.Application.Services.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;

namespace Livraria.Application.Services
{
    public class AutorService : ServiceBase<AutorViewModel, Autor>, IAutorService
    {
        public AutorService(IMapper mapper, IAutorRepository repository) : base(mapper, repository)
        {
        }
    }
}