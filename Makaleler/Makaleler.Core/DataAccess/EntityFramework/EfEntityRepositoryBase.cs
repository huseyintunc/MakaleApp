using Makaleler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Makaleler.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
      where TEntity : class, IEntity, new()
      where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter ?? throw new ArgumentNullException(nameof(filter)));
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var addEntity = context.Entry(entity);
                        addEntity.State = EntityState.Added;
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }

            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var updateEntity = context.Entry(entity);
                        updateEntity.State = EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                    }
                }

            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var deleteEntity = context.Entry(entity);
                        deleteEntity.State = EntityState.Deleted;
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {

                        transaction.Rollback();
                    }
                }

            }
        }

        public bool Exists(Expression<Func<TEntity, bool>> whereCondition)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Any(whereCondition);
            }
        }

        public int Count(Expression<Func<TEntity, bool>> whereCondition)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(whereCondition).Count();
            }
        }

        public int Count(TEntity entity)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter ?? throw new ArgumentNullException(nameof(filter)));
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await (filter == null ? context.Set<TEntity>().ToListAsync() : context.Set<TEntity>().Where(filter).ToListAsync());
            }
        }
    }
}
