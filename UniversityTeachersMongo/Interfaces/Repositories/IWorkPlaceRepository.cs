using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface IWorkPlaceRepository
{
    Task<IEnumerable<WorkPlace>> GetAllAsync();

    Task<WorkPlace> GetByIdAsync(int id);
}