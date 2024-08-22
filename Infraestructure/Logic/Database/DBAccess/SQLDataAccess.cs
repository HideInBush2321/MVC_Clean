using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Interfaces.DBAccess;


namespace Infraestructure.DBAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;
        private readonly string _nome = "DB";

        public SQLDataAccess(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<IEnumerable<T>> SelectAsync<T>(string query, object? parametros = null)
        {
            using (IDbConnection conexao = new SqlConnection(_config.GetConnectionString(_nome)))
            {
                return await conexao.QueryAsync<T>(query, parametros);
            }
        }
        public async Task InsertUpdateAsync<T>(string Query, T data)
        {
            using (IDbConnection conexao = new SqlConnection(_config.GetConnectionString(_nome)))
            {
                await conexao.ExecuteAsync(Query, data);
            }
        }
        public async Task DeleteAsync(string Query, object? Parametros = null)
        {
            using (IDbConnection conexao = new SqlConnection(_config.GetConnectionString(_nome)))
            {
                await conexao.ExecuteAsync(Query, Parametros);
            }
        }
    }
}
