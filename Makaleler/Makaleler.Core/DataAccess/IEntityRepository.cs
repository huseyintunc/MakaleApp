using Makaleler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Makaleler.Core.DataAccess
{
  public interface IEntityRepository<T> where T:class ,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(Expression<Func<T, bool>> whereCondition);
        int Count(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    }
}
