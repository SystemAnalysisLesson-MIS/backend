using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IkematgahDegisim.Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T> where T:class,IEntity,new()
    {
        T Add(T entity);
        T Delete(T entity);

        T Update(T entity);

        void DeleteByID(int Id);

        void UpdateByID(int Id);

        void AddEntity(T entity);

        IList<T> GetAll(Expression<Func<T, bool>> filter = null);

        T GetByFilter(Expression<Func<T, bool>> filter);

        IQueryable<T> GetByQueryByFilter(Expression<Func<T, bool>> filter);

        T Find(params object[] keyvalues);
    }
}
