namespace UniversityTeachersEF.Data.Entities
{
    public class Position
    {
        public Position()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SalaryPerHour { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
