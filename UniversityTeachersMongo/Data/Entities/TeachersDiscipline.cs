using MongoDB.Bson;

namespace UniversityTeachersMongo.Data.Entities
{
    public class TeachersDiscipline
    {
        public ObjectId Id { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }
        public int NumOfHours { get; set; }
    }
}
