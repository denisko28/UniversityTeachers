namespace UniversityTeachersEF.DTOs;

public class TeacherFullResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string PhoneNum { get; set; } = null!;
    public int HomeAddressId { get; set; }
    public string HomeFullAddress { get; set; } = null!;
    public int WorkPlaceId { get; set; }
    public string WorkPlaceName { get; set; } = null!;
    public int PositionId { get; set; }
    public string PositionName { get; set; } = null!;
    public string? Characteristic { get; set; }
}
