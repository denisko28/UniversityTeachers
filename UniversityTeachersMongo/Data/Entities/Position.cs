﻿namespace UniversityTeachersMongo.Data.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SalaryPerHour { get; set; }
    }
}
