using System.Data;
using System.Data.Common;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using UniversityTeachersADO.Data.Connection;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Data.Exceptions;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Data.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly DbConnection _connection;

    public TeacherRepository(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Teachers";
        var teachers = new List<Teacher>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                teachers.Add(
                    new Teacher
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Surname = reader.GetString("Surname"),
                        Patronymic = reader.GetString("Patronymic"),
                        PhoneNum = reader.GetString("PhoneNum"),
                        HomeAddressId = reader.GetInt32("HomeAddressId"),
                        WorkPlaceId = reader.GetInt32("WorkPlaceId"),
                        PositionId = reader.GetInt32("PositionId"),
                    }
                );
            }
        }
        finally
        {
            await _connection.CloseAsync();
        }

        return teachers;
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Teachers WHERE Id=@Id";

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;
            var idParameter = new SqlParameter("@Id", id);
            command.Parameters.Add(idParameter);

            await using var reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();

            if (!reader.HasRows)
                throw new EntityNotFoundException(nameof(Teacher), id);

            return new Teacher
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Surname = reader.GetString("Surname"),
                Patronymic = reader.GetString("Patronymic"),
                PhoneNum = reader.GetString("PhoneNum"),
                HomeAddressId = reader.GetInt32("HomeAddressId"),
                WorkPlaceId = reader.GetInt32("WorkPlaceId"),
                PositionId = reader.GetInt32("PositionId"),
            };
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<dynamic> GetByIdFullEntityAsync(int id)
    {
        const string sql = @"SELECT Teachers.id AS 'id', Teachers.name AS 'name', surname, patronymic, phoneNum, 
        HomeAddressId, Streets.streetName AS 'homeAddressStreet', HomeAddresses.flatNum AS 'homeAddressFlatNum',
        HomeAddresses.building AS 'homeAddressBuilding', workPlaceId, WorkPlaces.placeName AS 'workPlaceName',
        positionId, Positions.Name AS 'positionName' 
        FROM Teachers 
        INNER JOIN HomeAddresses ON HomeAddresses.Id = HomeAddressId
        INNER JOIN WorkPlaces ON WorkPlaces.Id = workPlaceId
        INNER JOIN Positions ON Positions.Id = positionId
        INNER JOIN Streets ON Streets.Id = HomeAddresses.streetId
        WHERE Teachers.id = @Id";

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;
            var idParameter = new SqlParameter("@Id", id);
            command.Parameters.Add(idParameter);

            await using var reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();

            if (!reader.HasRows)
                throw new EntityNotFoundException(nameof(Teacher), id);

            dynamic teacher = new ExpandoObject();
            teacher.Id = reader.GetInt32("id");
            teacher.Name = reader.GetString("name");
            teacher.Surname = reader.GetString("surname");
            teacher.Patronymic = reader.GetString("patronymic");
            teacher.PhoneNum = reader.GetString("phoneNum");
            teacher.HomeAddressId = reader.GetInt32("homeAddressId");
            teacher.HomeAddressStreet = reader.GetString("homeAddressStreet");
            teacher.HomeAddressFlatNum = 
                reader.IsDBNull(reader.GetOrdinal("homeAddressFlatNum")) ? 0 : reader["homeAddressFlatNum"];
            teacher.HomeAddressBuilding = reader.GetString("homeAddressBuilding");
            teacher.WorkPlaceId = reader.GetInt32("workPlaceId");
            teacher.WorkPlaceName = reader.GetString("workPlaceName");
            teacher.PositionId = reader.GetInt32("positionId");
            teacher.PositionName = reader.GetString("positionName");
            return teacher;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IEnumerable<dynamic>> GetTeachersDisciplines(int teacherId)
    {
        const string sql = @"SELECT teacherId, Disciplines.name AS 'disciplineName', numOfHours FROM TeachersDisciplines
        INNER JOIN Disciplines ON disciplineId = Disciplines.id 
        WHERE teacherId=@TeacherId";
        
        var disciplines = new List<ExpandoObject>();

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;
            var teacherIdParameter = new SqlParameter("@TeacherId", teacherId);
            command.Parameters.Add(teacherIdParameter);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                dynamic discipline = new ExpandoObject();
                discipline.TeacherId = reader.GetInt32("teacherId");
                discipline.DisciplineName = reader.GetString("disciplineName");
                discipline.NumOfHours = reader.GetInt32("numOfHours");
                disciplines.Add(discipline);
            }

            return disciplines;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<TeachersCharacteristic> GetCharacteristic(int teacherId)
    {
        const string sql = "SELECT * FROM TeachersCharacteristics WHERE teacherId=@TeacherId";

        await _connection.OpenAsync();

        try
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;
            var teacherIdParameter = new SqlParameter("@TeacherId", teacherId);
            command.Parameters.Add(teacherIdParameter);

            await using var reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();

            if (!reader.HasRows)
                throw new EntityNotFoundException(nameof(TeachersCharacteristic), teacherId);

            return new TeachersCharacteristic
            {
                TeacherId = reader.GetInt32("teacherId"),
                Characteristic = reader.GetString("characteristic")
            };
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    // public async Task<bool> CreateAsync(Teacher teacher)
    // {
    //     var propInfo = teacher.GetType().GetProperties()
    //         .Select(p=> p).Where(p => p.Name != "Id").ToArray();
    //     var propertiesArr = propInfo.Select(p => "@" + p.Name).ToString();
    //     var propertiesStr = string.Join(", ", propertiesArr);
    //     
    //     var sql = "INSERT INTO Teachers VALUES (" + propertiesStr + ")";
    //     
    //     var command = _connection.CreateCommand();
    //     command.CommandText = sql;
    //     foreach (var prop in propInfo)
    //     {
    //         var parameter = new SqlParameter("@" + prop.Name, prop.GetValue(teacher, null)!);
    //         command.Parameters.Add(parameter);   
    //     }
    //
    //     var result = await command.ExecuteNonQueryAsync();
    //     
    //     return result >= 1;
    // }
}