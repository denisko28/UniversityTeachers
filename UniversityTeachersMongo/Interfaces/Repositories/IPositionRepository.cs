using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetAllAsync();

    Task<Position> GetByIdAsync(int id);
}