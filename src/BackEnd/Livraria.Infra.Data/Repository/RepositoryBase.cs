using Livraria.Domain.Repository.Interfaces;
using Livraria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Livraria.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly LivrariaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(LivrariaContext livrariaContext)
        {
            Db = livrariaContext;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Db.Add(entity);
            Db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(DbSet.Find(id));
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}