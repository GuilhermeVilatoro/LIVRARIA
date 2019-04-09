using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;
using Livraria.Infra.Data.Context;
using System.Linq;

namespace Livraria.Infra.Data.Repository
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(LivrariaContext livrariaContext) : base(livrariaContext)
        {
        }      

        public bool ExisteAutorVinculadoNoLivro(int livroId, int autorId)
        {
            return GetAll().Any(l => l.Id == livroId && l.AutorId == autorId);
        }
    }
}