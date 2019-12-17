using Dapper;
using IkematgahDegisim.Core.DataAccess.Abstract;
using IkematgahDegisim.Core.Entities.Abstract;
using IkematgahDegisim.Core.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IkematgahDegisim.Core.DataAccess.Concerete.Dapper
{
    public class GenericDapperRepositoryBase<T> : IDapperRepositoryBase<T> where T : class, IEntity, new()
    {
        public string GetConnectionString(string name = "IkematgahDegisimContext", string pathName = "appsettings.json")
        {
            var configurationBuilder = new ConfigurationBuilder();
            var root = configurationBuilder.BuildYourConfiguration(pathName);
            return root.GetConnectionString(name);
        }

        private DynamicParameters Parameters { get; set; }
        public void AddParameter(string name, object value, DbType type)
        {
            if (Parameters != null)
                Parameters.Add(name, value, type);

            Parameters = new DynamicParameters();
        }

        public void Clear()
        {
            if (Parameters != null)
                Parameters = new DynamicParameters();
        }

        public IDbConnection CreateConnection(string connectionString="")
        {
            var conn = GetDbConnection(connectionString);
            conn.Open();
            return conn;
        }

        public IEnumerable<T> ExecuteQuery(string query)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(query).ToList();
            }
        }

        public IEnumerable<T> ExecuteQueryWithParams(string query)
        {
            var connectionString = GetConnectionString();

            using (var connection = CreateConnection(connectionString))
            {
                var result=connection.Query<T>(query,Parameters).ToList();
                Clear();
                return result;
            }
        }

        public IEnumerable<T> ExecuteSPQuery(string storedProcedureName)
        {
            var connectionString = GetConnectionString();

            using (var connection = CreateConnection(connectionString))
            {
                return connection.Query<T>(storedProcedureName,CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<T> ExecuteSPQueryWithParams(string storedProcedureName)
        {
            var connectionString = GetConnectionString();

            using (var connection = CreateConnection(connectionString))
            {
                var result = connection.Query<T>(storedProcedureName,CommandType.StoredProcedure).ToList();
                Clear();
                return result;
            }
        }

        public IDbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        IEnumerable<TEntity> IDapperRepositoryBase<T>.GetRelatedValues<TEntity, TFirstEntity>(string query, Func<TEntity, TFirstEntity, TEntity> func, string splitOn)
        {
            var connectionString = GetConnectionString();

            using (var conn = CreateConnection(connectionString))
            {
                var result = conn.Query<TEntity, TFirstEntity, TEntity>(query, func, splitOn: splitOn, commandTimeout: 600).Distinct().ToList();
                Clear();
                return result.ToList();
            }
        }

            IEnumerable<TEntity> IDapperRepositoryBase<T>.GetRelatedValues<TEntity, TFirstEntity, TSecondEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TEntity> func, string splitOn)
        {
            var connectionString = GetConnectionString();

            using (var conn = CreateConnection(connectionString))
            {
                var result = conn.Query<TEntity, TFirstEntity, TSecondEntity, TEntity>(query, func, splitOn: splitOn, commandTimeout: 600).Distinct().ToList();
                Clear();
                return result.ToList();
            }
        }

        IEnumerable<TEntity> IDapperRepositoryBase<T>.GetRelatedValues<TEntity, TFirstEntity, TSecondEntity, TThirdEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TEntity> func, string splitOn)
        {
            var connectionString = GetConnectionString();

            using (var conn = CreateConnection(connectionString))
            {
                var result = conn.Query<TEntity, TFirstEntity, TSecondEntity,TThirdEntity, TEntity>(query, func, splitOn: splitOn, commandTimeout: 600).Distinct().ToList();
                Clear();
                return result.ToList();
            }
        }

        IEnumerable<TEntity> IDapperRepositoryBase<T>.GetRelatedValues<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TFourthEntity>(string query, Func<TEntity, TFirstEntity, TSecondEntity, TThirdEntity, TFourthEntity, TEntity> func, string splitOn)
        {
            var connectionString = GetConnectionString();
            using (var conn = CreateConnection(connectionString))
            {
                var result = conn.Query<TEntity, TFirstEntity, TSecondEntity, TThirdEntity,TFourthEntity, TEntity>(query, func, splitOn: splitOn, commandTimeout: 600).Distinct().ToList();
                Clear();
                return result.ToList();
            }
        }
    }
}
