using Livraria.Domain.Business.Dto;
using Livraria.Domain.Business.Interfaces;
using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;
using System;

namespace Livraria.Domain.Business
{
    public class VinculacaoAutorNoLivroBusiness : IVinculacaoAutorNoLivroBusiness
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;

        public VinculacaoAutorNoLivroBusiness(ILivroRepository livroRepository,
            IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        public Livro VincularAutorNoLivro(VinculacaoAutorLivroDto vinculacaoAutorLivro)
        {
            if (vinculacaoAutorLivro == null)
                throw new System.ArgumentNullException(nameof(vinculacaoAutorLivro));

            var identificadorLivro = vinculacaoAutorLivro.LivroId;
            var livro = _livroRepository.GetById(identificadorLivro);
            if (livro == null)
                throw new Exception($"O livro de identificador {identificadorLivro} não existe!");

            var identificadorAutor = vinculacaoAutorLivro.AutorId;
            var autor = _autorRepository.GetById(identificadorAutor);
            if (autor == null)
                throw new Exception($"O autor de identificador {identificadorAutor} não existe!");

            if (_livroRepository.ExisteAutorVinculadoNoLivro(identificadorLivro, identificadorAutor))
                throw new Exception($"O autor já está cadastrado no livro!");

            livro.Autor = autor;
            livro.AutorId = autor.Id;
            _livroRepository.Update(livro);

            return livro;
        }
    }
}