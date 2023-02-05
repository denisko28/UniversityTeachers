using Microsoft.EntityFrameworkCore;
using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Data
{
    public class UniversityTeachersDbContext : DbContext
    {
        public UniversityTeachersDbContext()
        {
        }

        public UniversityTeachersDbContext(DbContextOptions<UniversityTeachersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Discipline> Disciplines { get; set; } = null!;
        public virtual DbSet<HomeAddress> HomeAddresses { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Street> Streets { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeachersCharacteristic> TeachersCharacteristics { get; set; } = null!;
        public virtual DbSet<TeachersDiscipline> TeachersDisciplines { get; set; } = null!;
        public virtual DbSet<WorkPlace> WorkPlaces { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HomeAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Building)
                    .HasMaxLength(8)
                    .HasColumnName("building");

                entity.Property(e => e.FlatNum).HasColumnName("flatNum");

                entity.Property(e => e.StreetId).HasColumnName("streetId");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.HomeAddresses)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK__HomeAddre__stree__3F466844");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(60);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .HasColumnName("streetName");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HomeAddressId).HasColumnName("homeAddressId");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(12)
                    .HasColumnName("phoneNum");

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.WorkPlaceId).HasColumnName("workPlaceId");

                entity.HasOne(d => d.HomeAddress)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.HomeAddressId)
                    .HasConstraintName("FK__Teachers__homeAd__4222D4EF");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Teachers__positi__440B1D61");

                entity.HasOne(d => d.WorkPlace)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.WorkPlaceId)
                    .HasConstraintName("FK__Teachers__workPl__4316F928");
            });

            modelBuilder.Entity<TeachersCharacteristic>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK__Teachers__EDF259641F52965A");

                entity.Property(e => e.TeacherId).ValueGeneratedNever();

                entity.Property(e => e.Characteristic).HasMaxLength(1500);

                entity.HasOne(d => d.Teacher)
                    .WithOne(p => p.TeachersCharacteristic)
                    .HasForeignKey<TeachersCharacteristic>(d => d.TeacherId)
                    .HasConstraintName("FK__TeachersC__Teach__4AB81AF0");
            });

            modelBuilder.Entity<TeachersDiscipline>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.DisciplineId })
                    .HasName("PK_Teacher_Discipline");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");

                entity.Property(e => e.NumOfHours).HasColumnName("numOfHours");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.TeachersDisciplines)
                    .HasForeignKey(d => d.DisciplineId)
                    .HasConstraintName("FK__TeachersD__disci__47DBAE45");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersDisciplines)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeachersD__teach__46E78A0C");
            });

            modelBuilder.Entity<WorkPlace>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.PlaceName)
                    .HasMaxLength(80)
                    .HasColumnName("placeName");
            });
        }
    }
}
