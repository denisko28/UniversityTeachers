using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class HomeAddressRepository : IHomeAddressRepository
{
    private readonly DbConnection _connection;

    public HomeAddressRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<HomeAddress>> GetAllAsync()
    {
        const string sql = "SELECT * FROM HomeAddresses";
        var homeAddresses = new List<HomeAddress>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                homeAddresses.Add(
                    new HomeAddress
                    {
                        Id = reader.GetInt32("id"),
                        StreetId = reader.GetInt32("streetId"),
                        Building = reader.GetString("building"),
                        FlatNum = reader.IsDBNull(reader.GetOrdinal("flatNum")) ? null : (int) reader["flatNum"]
                    }
                );
            }
        }
        finally
        {
            await _connection.CloseAsync();
        }

        return homeAddresses;
    }
}