using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;


namespace Services.BusinessLogic
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;
        private readonly string _nome = "NETCORE6";

        //Esta recebendo IConfiguration, pois dessa forma conseguimos acessar os dados do appsettings.json onde conseguimos ter acesso a diversas informacoes do arquivo etc etc etc
        public SQLDataAccess(IConfiguration config)
        {
            this._config = config;
        }

        public List<T> Select<T>(string query, object? parametros = null)
        {
            using (IDbConnection conexao = new SqlConnection(_config.GetConnectionString(_nome)))
            {
                return conexao.Query<T>(query, parametros).ToList();
            }
        }
    }
}
