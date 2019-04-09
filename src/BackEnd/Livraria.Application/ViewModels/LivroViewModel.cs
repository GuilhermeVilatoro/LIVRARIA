using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Application.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o número de páginas")]
        [Range(typeof(int), "0", "999999")]
        [DisplayName("Número de páginas")]
        public int NumeroDePaginas { get; set; }

        [Required(ErrorMessage = "Preencha a edição")]
        [Range(typeof(int), "0", "100")]
        [DisplayName("Edição")]
        public int Edicao { get; set; }

        [Required(ErrorMessage = "Preencha o ano de publicação")]
        [DisplayName("Data Publicação")]
        public DateTime Ano { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Autor")]
        public int AutorId { get; set; }

        public virtual AutorViewModel Autor { get; set; }
    }
}