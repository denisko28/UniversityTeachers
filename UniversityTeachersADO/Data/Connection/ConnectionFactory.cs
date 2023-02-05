using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace UniversityTeachersADO.Data.Connection;

public class ConnectionFactory
{
    public ConnectionFactory(IConfiguration configuration) =>
        Configuration = configuration;

    private IConfiguration Configuration { get; }

    public DbConnection GetConnection()
    {
        var connectionString = Configuration.GetConnectionString("MSSQLConnection");
        return new SqlConnection(connectionString);
    }
}