using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace TasksProjectBackend.Repositories
{
    public class BooksDataSql
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public BooksDataSql(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("MSSQL");
        }

        private IDbConnection GetDbConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }

        public async Task<List<BooksObj>> GetAll()
        {
            var conn = GetDbConnection();
            string sql = "select * from books";
            var books = await conn.QueryAsync<BooksObj>(sql);
            return books.ToList<BooksObj>();
        }

        public async Task<List<BooksObj>> GetAllSP()
        {
            using (var conn = GetDbConnection())
            {
                var books = await conn.QueryAsync<BooksObj>(
                                   "GetAllBooks",
                                   commandType: CommandType.StoredProcedure);

                return books.ToList<BooksObj>();
            }
        }

        public async Task<BooksObj> GetBookByID(int id)
        {
            using (var conn = GetDbConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", id, dbType: DbType.Int32);

                var book = await conn.QueryAsync<BooksObj>(
                    "GetBookByID",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return book.FirstOrDefault<BooksObj>();
            }
        }
    }
}
