using System;

namespace Livraria.Domain.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int NumeroDePaginas { get; set; }

        public int Edicao { get; set; }

        public DateTime Ano { get; set; }
        
        public string Descricao { get; set; }

        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; }
    }
}