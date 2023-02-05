namespace UniversityTeachersEF.DTOs;

public class TeachersDisciplinesResponse
{
    public int TeacherId { get; set; }
    public string DisciplineName { get; set; } = null!;
    public int NumOfHours { get; set; }
}