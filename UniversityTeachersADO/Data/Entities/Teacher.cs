namespace UniversityTeachersADO.Data.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;
        public int HomeAddressId { get; set; }
        public int WorkPlaceId { get; set; }
        public int PositionId { get; set; }
    }
}
