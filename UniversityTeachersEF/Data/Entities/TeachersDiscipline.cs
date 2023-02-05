namespace UniversityTeachersEF.Data.Entities
{
    public class TeachersDiscipline
    {
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }
        public int NumOfHours { get; set; }

        public virtual Discipline Discipline { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
