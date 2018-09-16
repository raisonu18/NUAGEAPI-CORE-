using COREAPI.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services.Imp
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private NUAGEDbContext entities = null;
        DbSet<TEntity> _objectSet;

        public Repository(NUAGEDbContext _entities)
        {
            entities = _entities;
            _objectSet = entities.Set<TEntity>();
        }

        public IEnumerable<TEntity> Query(Func<TEntity, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }

        public TEntity One(Func<TEntity, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _objectSet.Add(entity);
        }

        public void Attach(TEntity entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            _objectSet.Remove(entity);
        }

        public IEnumerable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }
        public bool Any(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _objectSet.Any(predicate);
        }
        public bool All(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _objectSet.All(predicate);
        }
        public TEntity Exists(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _objectSet.Find(predicate);
        }
        public int Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _objectSet.Count(predicate);
        }
    }
}
