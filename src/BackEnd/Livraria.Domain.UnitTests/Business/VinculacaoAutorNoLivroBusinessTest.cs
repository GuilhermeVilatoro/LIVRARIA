using Livraria.Domain.Business;
using Livraria.Domain.Business.Dto;
using Livraria.Domain.Models;
using Livraria.Domain.Repository.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Livraria.Domain.UnitTests.Business
{
    public class VinculacaoAutorNoLivroBusinessTest
    {
        private ILivroRepository livroRepositoryMock;
        private IAutorRepository autorRepositoryMock;

        private VinculacaoAutorLivroDto vinculacaoAutorLivroMock;

        private Livro livroMock;
        private Autor autorMock;

        [SetUp]
        public void SetUp()
        {
            livroRepositoryMock = Substitute.For<ILivroRepository>();            
            autorRepositoryMock = Substitute.For<IAutorRepository>();

            vinculacaoAutorLivroMock = Substitute.For<VinculacaoAutorLivroDto>();
            vinculacaoAutorLivroMock.AutorId = 1;
            vinculacaoAutorLivroMock.LivroId = 1;

            livroMock = Substitute.For<Livro>();
            livroMock.Id = vinculacaoAutorLivroMock.LivroId;

            autorMock = Substitute.For<Autor>();
            livroMock.Id = vinculacaoAutorLivroMock.AutorId;

            livroRepositoryMock.ExisteAutorVinculadoNoLivro(vinculacaoAutorLivroMock.LivroId,
                vinculacaoAutorLivroMock.AutorId).Returns(false);
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Vincular_Um_Autor_Em_Um_Livro_Inexistente()
        {
            Assert.Throws<Exception>(
                () => new VinculacaoAutorNoLivroBusiness(livroRepositoryMock, autorRepositoryMock)
                .VincularAutorNoLivro(vinculacaoAutorLivroMock),                   
                   "O livro não deve existir!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Vincular_Um_Autor_Inexistente_Em_Um_Livro()
        {
            livroRepositoryMock.GetById(vinculacaoAutorLivroMock.LivroId).Returns(livroMock);

            Assert.Throws<Exception>(
                () => new VinculacaoAutorNoLivroBusiness(livroRepositoryMock, autorRepositoryMock)
                .VincularAutorNoLivro(vinculacaoAutorLivroMock),
                   "O autor não deve existir!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Vincular_Um_Autor_Ja_Cadastrado_No_Livro()
        {
            livroRepositoryMock.GetById(vinculacaoAutorLivroMock.LivroId).Returns(livroMock);
            autorRepositoryMock.GetById(vinculacaoAutorLivroMock.AutorId).Returns(autorMock);

            livroRepositoryMock.ExisteAutorVinculadoNoLivro(vinculacaoAutorLivroMock.LivroId,
                vinculacaoAutorLivroMock.AutorId).Returns(true);

            Assert.Throws<Exception>(
                 () => new VinculacaoAutorNoLivroBusiness(livroRepositoryMock, autorRepositoryMock)
                 .VincularAutorNoLivro(vinculacaoAutorLivroMock),
                    "O autor já deve estar cadastro neste livro!");
        }

        [Test]
        public void Deve_Realizar_Vinculo_Do_Autor_Com_Livro_Quando_O_Livro_E_Autor_Existitem()
        {
            livroRepositoryMock.GetById(vinculacaoAutorLivroMock.LivroId).Returns(livroMock);
            autorRepositoryMock.GetById(vinculacaoAutorLivroMock.AutorId).Returns(autorMock);

            new VinculacaoAutorNoLivroBusiness(livroRepositoryMock, autorRepositoryMock)
                .VincularAutorNoLivro(vinculacaoAutorLivroMock);

            livroRepositoryMock.ReceivedWithAnyArgs(1).Update(livroMock);          
        }
    }
}