using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly DbConnection _connection;

    public PositionRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<Position>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Positions";
        var positions = new List<Position>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                positions.Add(
                    new Position
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        SalaryPerHour = reader.GetInt32("salaryPerHour")
                    }
                );
            }
        }
        finally
        {
            await _connection.CloseAsync();
        }

        return positions;
    }
}