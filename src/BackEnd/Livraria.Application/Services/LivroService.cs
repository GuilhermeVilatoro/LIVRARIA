using AutoMapper;
using Livraria.Application.Services.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;

namespace Livraria.Application.Services
{
    public class LivroService : ServiceBase<LivroViewModel, Livro>, ILivroService
    {
        public LivroService(IMapper mapper, ILivroRepository repository) : base(mapper, repository)
        {
        }
    }
}