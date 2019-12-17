using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IkematgahDegisim.Core.DataAccess.Abstract
{
    public interface IDapperRepositoryBase<T> where T : class, IEntity, new()
    {
        IEnumerable<T> ExecuteQuery(string query);
        IEnumerable<T> ExecuteSPQuery(string storedProcedureName);
        IEnumerable<T> ExecuteQueryWithParams(string query);
        IEnumerable<T> ExecuteSPQueryWithParams(string storedProcedureName);
        IDbConnection GetDbConnection(string connectionString);
        IDbConnection CreateConnection(string connectionString);

        IEnumerable<TEntity> GetRelatedValues<TEntity, TFirstEntity>(string query, Func<TEntity, TFirstEntity, TEntity> func, string splitOn)
           where TFirstEntity : class, IEntity, new()
           where TEntity : class, IEntity, new();

        IEnumerable<TEntity> GetRelatedValues<TEntity, TFirstEntity, TSecondEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TEntity> func, string splitOn)
              where TFirstEntity : class, IEntity, new()
              where TSecondEntity : class, IEntity, new()
              where TEntity : class, IEntity, new();


        IEnumerable<TEntity> GetRelatedValues<TEntity, TFirstEntity, TSecondEntity, TThirdEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TEntity> func, string splitOn)
            where TFirstEntity : class, IEntity, new()
            where TSecondEntity : class, IEntity, new()
            where TThirdEntity : class, IEntity, new()
            where TEntity : class, IEntity, new();

        IEnumerable<TEntity> GetRelatedValues<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TFourthEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TFourthEntity, TEntity> func, string splitOn)
           where TFirstEntity : class, IEntity, new()
           where TSecondEntity : class, IEntity, new()
           where TThirdEntity : class, IEntity, new()
           where TFourthEntity : class, IEntity, new()
           where TEntity : class, IEntity, new();

    }
}
