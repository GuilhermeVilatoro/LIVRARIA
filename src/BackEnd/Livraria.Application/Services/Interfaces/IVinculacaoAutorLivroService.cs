using Livraria.Application.ViewModels;

namespace Livraria.Application.Services.Interfaces
{
    public interface IVinculacaoAutorLivroService
    {
        LivroViewModel VincularAutorNoLivro(VinculacaoAutorLivroViewModel vinculacaoAutorLivro);
    }
}