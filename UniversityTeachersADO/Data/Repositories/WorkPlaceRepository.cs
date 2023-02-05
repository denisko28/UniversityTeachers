using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class WorkPlaceRepository : IWorkPlaceRepository
{
    private readonly DbConnection _connection;

    public WorkPlaceRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<WorkPlace>> GetAllAsync()
    {
        const string sql = "SELECT * FROM WorkPlaces";
        var streets = new List<WorkPlace>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                streets.Add(
                    new WorkPlace
                    {
                        Id = reader.GetInt32("id"),
                        PlaceName = reader.GetString("placeName"),
                        Address = reader.GetString("address")
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