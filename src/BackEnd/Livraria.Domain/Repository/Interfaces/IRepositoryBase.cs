using System;
using System.Collections.Generic;

namespace Livraria.Domain.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Responsável por inserir um registro na entidade.
        /// </summary>
        /// <param name="entity">Entidade informada que será realizada a persistência</param>
        void Add(TEntity entity);

        /// <summary>
        /// Responsável por alterar um registro na entidade.
        /// </summary>
        /// <param name="entity">Entidade informada que será realizada a persistência</param>
        void Update(TEntity entity);

        /// <summary>
        /// Responsável por deletar um registro na entidade pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        void Delete(int id);

        /// <summary>
        /// Responsável por deletar um registro de acordo com a entidade.
        /// </summary>
        /// <param name="entity">Entidade informada que será realizada a persistência</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Responsável por realizar a busca do registo por identificador.
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        TEntity GetById(int id);

        /// <summary>
        /// Responsável por buscar todos os registros de uma entidade.
        /// </summary>        
        IEnumerable<TEntity> GetAll();
    }
}