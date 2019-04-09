using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;
using Livraria.Infra.Data.Context;

namespace Livraria.Infra.Data.Repository
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(LivrariaContext livrariaContext) : base(livrariaContext)
        {
        }
    }
}