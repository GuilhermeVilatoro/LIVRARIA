using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;
using Livraria.Infra.Data.Context;

namespace Livraria.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LivrariaContext livrariaContext) : base(livrariaContext)
        {
        }
    }
}