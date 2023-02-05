namespace UniversityTeachersADO.DTOs
{
    public class HomeAddressResponse
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public string Building { get; set; } = null!;
        public int? FlatNum { get; set; }
    }
}
