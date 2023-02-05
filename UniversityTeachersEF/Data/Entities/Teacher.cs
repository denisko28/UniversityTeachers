namespace UniversityTeachersEF.Data.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            TeachersDisciplines = new HashSet<TeachersDiscipline>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;
        public int HomeAddressId { get; set; }
        public int WorkPlaceId { get; set; }
        public int PositionId { get; set; }

        public virtual HomeAddress HomeAddress { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
        public virtual WorkPlace WorkPlace { get; set; } = null!;
        public virtual TeachersCharacteristic TeachersCharacteristic { get; set; } = null!;
        public virtual ICollection<TeachersDiscipline> TeachersDisciplines { get; set; }
    }
}
