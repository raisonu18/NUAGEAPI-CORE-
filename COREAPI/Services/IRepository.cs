using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity One(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Query(Func<TEntity, bool> predicate = null);
        bool Any(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        bool All(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        TEntity Exists(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        int Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
    }
}
