namespace UniversityTeachersADO.Data.Entities
{
    public class HomeAddress
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public string Building { get; set; } = null!;
        public int? FlatNum { get; set; }
    }
}
