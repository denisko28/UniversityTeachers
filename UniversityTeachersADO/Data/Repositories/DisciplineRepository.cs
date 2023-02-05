using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly DbConnection _connection;

    public DisciplineRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<Discipline>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Disciplines";
        var disciplines = new List<Discipline>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                disciplines.Add(
                    new Discipline
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name")
                    }
                );
            }
        }
        finally
        {
            await _connection.CloseAsync();
        }

        return disciplines;
    }
}