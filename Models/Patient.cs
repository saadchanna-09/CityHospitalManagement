using System;
using System.ComponentModel.DataAnnotations;

namespace CityHospitalManagement.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, RegularExpression(@"^(03)[0-9]{9}$", ErrorMessage = "Invalid Pakistani Mobile Number Format.")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        public string MedicalHistory { get; set; } = string.Empty;
    }
}