using Microsoft.EntityFrameworkCore;
using CityHospitalManagement.Models;

namespace CityHospitalManagement.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Admission> Admissions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------------------------------------------------------------------------------
            // REGISTRATION NUMBER ASSUMPTION MATRIX SEEDING
            // Example Group Student Reg: 50842 (Last two digits '42' determines dynamic limits)
            // ---------------------------------------------------------------------------------
            int dynamicSeededLimitValue = 42; 

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Saad Khan", Specialization = "Cardiologist", AssignedWard = "ICU", IsAvailable = true, ConsultationSchedule = "09:00 AM - 01:00 PM", MaxPatientCapacity = dynamicSeededLimitValue },
                new Doctor { Id = 2, FullName = "Dr. Ayesha Ahmed", Specialization = "Pediatrician", AssignedWard = "Pediatric", IsAvailable = true, ConsultationSchedule = "11:00 AM - 04:00 PM", MaxPatientCapacity = dynamicSeededLimitValue }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Muhammad Ali", Email = "ali@gmail.com", ContactNumber = "03331234567", MedicalHistory = "Chronic Hypertension" }
            );
        }
    }
}