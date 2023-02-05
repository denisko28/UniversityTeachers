using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface IStreetRepository
{
    Task<IEnumerable<Street>> GetAllAsync();

    Task<Street> GetByIdAsync(int id);
}