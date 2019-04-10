using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do usuário")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o a senha")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]     
        public string Senha { get; set; }
    }
}