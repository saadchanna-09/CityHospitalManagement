using System.ComponentModel.DataAnnotations;

namespace CityHospitalManagement.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        public string AssignedWard { get; set; } = string.Empty; // General, ICU, Maternity, Pediatric

        public bool IsAvailable { get; set; } = true;

        [Required]
        public string ConsultationSchedule { get; set; } = string.Empty; // e.g., "09:00 AM - 02:00 PM"

        public int MaxPatientCapacity { get; set; }
    }
}