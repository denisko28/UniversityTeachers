using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class StreetRepository : IStreetRepository
{
    private readonly DbConnection _connection;

    public StreetRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<Street>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Streets";
        var streets = new List<Street>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                streets.Add(
                    new Street
                    {
                        Id = reader.GetInt32("id"),
                        StreetName = reader.GetString("streetName")
                    }
                );
            }
        }
        finally
        {
            await _connection.CloseAsync();
        }

        return streets;
    }
}