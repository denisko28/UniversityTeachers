namespace UniversityTeachersEF.Data.Entities
{
    public class Discipline
    {
        public Discipline()
        {
            TeachersDisciplines = new HashSet<TeachersDiscipline>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TeachersDiscipline> TeachersDisciplines { get; set; }
    }
}
