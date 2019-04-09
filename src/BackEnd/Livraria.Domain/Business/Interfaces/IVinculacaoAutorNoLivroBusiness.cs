using Livraria.Domain.Business.Dto;
using Livraria.Domain.Models;

namespace Livraria.Domain.Business.Interfaces
{
    public interface IVinculacaoAutorNoLivroBusiness
    {
        /// <summary>
        /// Responsável por adicionar um determinado autor em um livro.
        /// </summary>
        /// <param name="vinculacaoAutorLivro">Dados do autor e do livro</param>
        /// <returns>Retorna o livro com as alterações de autor</returns>
        Livro VincularAutorNoLivro(VinculacaoAutorLivroDto vinculacaoAutorLivro);
    }
}