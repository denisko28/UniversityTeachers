namespace UniversityTeachersEF.Data.Entities
{
    public class Street
    {
        public Street()
        {
            HomeAddresses = new HashSet<HomeAddress>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;

        public virtual ICollection<HomeAddress> HomeAddresses { get; set; }
    }
}
