using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperDemo.Data
{

    public class DataContext
    {
        private readonly string? _connectionString ;
        public DataContext(IConfiguration config)
        {
            _connectionString = config?.GetConnectionString("DefaultConnection");
        }
        
        public IEnumerable<T> LoadData<T>(string sql)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
           return dbConnection.Query<T>(sql);     
        }

        public T LoadDataSingle<T>(string sql)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
           return dbConnection.QuerySingle<T>(sql);     
        }
        
        public bool ExecuteSql<T>(string sql)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
           return dbConnection.Execute(sql) > 0;     
        }
        
        public int ExecuteSqlWithRowCount<T>(string sql)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
           return dbConnection.Execute(sql);     
        }
    }
}