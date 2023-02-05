using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface IWorkPlaceRepository
{
    Task<IEnumerable<WorkPlace>> GetAllAsync();
}