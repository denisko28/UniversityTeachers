using MongoDB.Bson;

namespace UniversityTeachersMongo.Data.Entities
{
    public class TeachersCharacteristic
    {
        public ObjectId Id { get; set; }
        public int TeacherId { get; set; }
        public string? Characteristic { get; set; }
    }
}
