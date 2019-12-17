using IkematgahDegisim.Core.DataAccess.Abstract;
using IkematgahDegisim.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IkematgahDegisim.Core.DataAccess.Concerete.EntityFramework
{
    public class GenericEntityFrameworkRepositoryBase<T, TContext> : IEntityRepositoryBase<T> where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public T Add(T entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Added;
                context.SaveChanges();
            }

            return entity;
        }

        public void AddEntity(T entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public T Delete(T entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                context.SaveChanges();
            }
            return entity;
        }

        public void DeleteByID(int Id)
        {
            using (var context = new TContext())
            {
                var entity = context.Find<T>(Id);
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Find(params object[] keyvalues)
        {
            using (var context = new TContext())
            {
                return context.Find<T>(keyvalues);
            }
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter != null ? context.Set<T>().Where(filter).ToList() :
                    context.Set<T>().ToList();
            }
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public IQueryable<T> GetByQueryByFilter(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter != null ? context.Set<T>().Where(filter) :
                    context.Set<T>();
            }
        }

        public T Update(T entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
            return entity;
        }

        public void UpdateByID(int Id)
        {
            using (var context = new TContext())
            {
                var entity = context.Find<T>(Id);
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
