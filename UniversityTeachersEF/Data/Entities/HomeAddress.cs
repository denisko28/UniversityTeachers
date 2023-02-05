namespace UniversityTeachersEF.Data.Entities
{
    public class HomeAddress
    {
        public HomeAddress()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public int StreetId { get; set; }
        public string Building { get; set; } = null!;
        public int? FlatNum { get; set; }

        public virtual Street Street { get; set; } = null!;
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
