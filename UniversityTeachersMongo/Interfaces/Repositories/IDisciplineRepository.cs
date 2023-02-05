using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface IDisciplineRepository
{
    Task<IEnumerable<Discipline>> GetAllAsync();

    Task<Discipline> GetByIdAsync(int id);
}