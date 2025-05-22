using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Persistence
{
    internal interface IWriteDbConnection
    {
        IDbConnection CreateConnection();
    }
}
