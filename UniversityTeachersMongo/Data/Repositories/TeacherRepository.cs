using MongoDB.Driver;
using UniversityTeachersEF.Data.Exceptions;
using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    private readonly IMongoCollection<TeachersDiscipline> _teachersDisciplineCollection;
    private readonly IMongoCollection<TeachersCharacteristic> _teachersCharacteristicCollection;

    public TeacherRepository(MongoDbContext dbContext) : base(dbContext)
    {
        _teachersDisciplineCollection = DbContext.Collection<TeachersDiscipline>();
        _teachersCharacteristicCollection = DbContext.Collection<TeachersCharacteristic>();
    }

    public async Task<IEnumerable<TeachersDiscipline>> GetTeachersDisciplines(int teacherId)
    {
        return await _teachersDisciplineCollection
            .Find(x => x.TeacherId == teacherId).ToListAsync();
    }

    public async Task<TeachersCharacteristic> GetCharacteristic(int teacherId)
    {
        return await _teachersCharacteristicCollection
                   .Find(x => x.TeacherId == teacherId).FirstOrDefaultAsync()
               ?? throw new EntityNotFoundException(nameof(Teacher), teacherId);
    }
}