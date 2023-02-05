namespace UniversityTeachersEF.Data.Entities
{
    public class TeachersCharacteristic
    {
        public int TeacherId { get; set; }
        public string? Characteristic { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;
    }
}
