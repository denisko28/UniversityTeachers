using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync();

    Task<Teacher> GetByIdAsync(int id);

    Task<IEnumerable<TeachersDiscipline>> GetTeachersDisciplines(int teacherId);

    Task<TeachersCharacteristic> GetCharacteristic(int teacherId);
}