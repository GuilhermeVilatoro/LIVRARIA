using System;
using System.Collections.Generic;

namespace Livraria.Application.Services.Interfaces
{
    public interface IServiceBase<TEntityViewModel> : IDisposable where TEntityViewModel : class
    {
        /// <summary>
        /// Responsável por adicionar a entidade a partir de um viewmodel.
        /// </summary>
        /// <param name="entityViewModel"></param>
        void Add(TEntityViewModel entityViewModel);

        /// <summary>
        /// Responsável por alterar a entidade a partir de um viewmodel.
        /// </summary>
        /// <param name="entityViewModel"></param>
        void Update(TEntityViewModel entityViewModel);

        /// <summary>
        /// Responsável por deletar a entidade a partir de um identificador.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Responsável por deletar a entidade a partir de um viewmodel. 
        /// </summary>
        /// <param name="entityViewModel"></param>
        void Delete(TEntityViewModel entityViewModel);

        /// <summary>
        /// Responsável por buscar a entidade a partir de um identificador. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntityViewModel GetById(int id);

        /// <summary>
        /// Responsável por buscar todos os registors de uma determinada a entidade.
        /// </summary>
        /// <returns>Todos os registros</returns>
        IEnumerable<TEntityViewModel> GetAll();
    }
}