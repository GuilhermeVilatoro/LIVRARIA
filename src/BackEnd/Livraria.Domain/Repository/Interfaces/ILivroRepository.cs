using Livraria.Domain.Models;

namespace Livraria.Domain.Repository.Interfaces
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
        /// <summary>
        /// Responsável por verificar se determinado autor já esta vincualdo ao livro.
        /// </summary>
        /// <param name="livroId">Identificador do livro</param>
        /// <param name="autorId">Identificador do autor</param>
        /// <returns>Retorna verdadeiro se o autor já estiver vinculado ao livro</returns>
        bool ExisteAutorVinculadoNoLivro(int livroId, int autorId);
    }
}