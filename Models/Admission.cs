using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityHospitalManagement.Models
{
    public class Admission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } = null!;

        [Required]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; } = null!;

        [Required]
        public string WardType { get; set; } = string.Empty; // General, ICU, Maternity, Pediatric

        [Required]
        public int BedNumber { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        public DateTime? DischargeDate { get; set; }
        
        [Required]
        public string Status { get; set; } = string.Empty; // Active, Discharged
    }
}