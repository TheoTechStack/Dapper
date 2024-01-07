using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo.Data
{

    public class DataContext
    {
        private static string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa;Password=theoStrongPwd123;";
        
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