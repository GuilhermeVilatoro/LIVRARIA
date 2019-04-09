using System.ComponentModel.DataAnnotations;

namespace Livraria.Application.ViewModels
{
    public class VinculacaoAutorLivroViewModel
    {
        [Required(ErrorMessage = "Preencha o identificador do livro")]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Preencha o identificador do autor")]
        public int AutorId { get; set; }
    }
}