using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Persistence.SQLServer.Config
{
    public class SQLServerConnection : IWriteDbConnection
    {
        private readonly string _connectionString;

        public SQLServerConnection(IConfiguration configuration)
        {
            var a = configuration.GetConnectionString("DefaultConnection");
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
