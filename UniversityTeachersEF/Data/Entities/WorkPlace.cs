namespace UniversityTeachersEF.Data.Entities
{
    public class WorkPlace
    {
        public WorkPlace()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string PlaceName { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
