using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync();

    Task<Teacher> GetByIdAsync(int id);
    
    Task<Teacher> GetByIdFullEntityAsync(int id);

    Task<IEnumerable<TeachersDiscipline>> GetTeachersDisciplines(int teacherId);

    Task<TeachersCharacteristic> GetCharacteristic(int teacherId);
}