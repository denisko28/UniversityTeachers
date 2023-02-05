using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface IDisciplineRepository
{
    Task<IEnumerable<Discipline>> GetAllAsync();
}