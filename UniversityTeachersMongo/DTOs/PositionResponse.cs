namespace UniversityTeachersMongo.DTOs
{
    public class PositionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SalaryPerHour { get; set; }
    }
}
