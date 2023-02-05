using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync();

    Task<Teacher> GetByIdAsync(int id);
    
    Task<dynamic> GetByIdFullEntityAsync(int id);

    Task<IEnumerable<dynamic>> GetTeachersDisciplines(int teacherId);

    Task<TeachersCharacteristic> GetCharacteristic(int teacherId);
}