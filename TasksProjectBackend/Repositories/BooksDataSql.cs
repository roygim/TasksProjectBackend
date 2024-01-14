using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using TasksProjectBackend.SimpleObjects;
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

        public async Task<BooksObj> AddBook(BooksObj book)
        {
            using (var conn = GetDbConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", book.Name, dbType: DbType.String);
                parameters.Add("@Year", book.Year, dbType: DbType.Int32);
                parameters.Add("@MaxDays", book.MaxDays, dbType: DbType.Int32);
                parameters.Add("@Faculty", book.Faculty, dbType: DbType.String);
                parameters.Add("@Pages", book.Pages, dbType: DbType.Int32);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await conn.ExecuteAsync("AddNewBook", parameters, commandType: CommandType.StoredProcedure);

                int newId = parameters.Get<int>("@NewId");
                book.ID = newId;

                return book;
            }
        }
    }
}
