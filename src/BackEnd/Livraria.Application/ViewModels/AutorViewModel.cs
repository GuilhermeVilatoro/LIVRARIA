using System.ComponentModel.DataAnnotations;

namespace Livraria.Application.ViewModels
{
    public class AutorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do autor")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o sobrenome do autor")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string Sobrenome { get; set; }
    }
}