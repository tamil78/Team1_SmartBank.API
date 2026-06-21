using System;
using System.ComponentModel.DataAnnotations;

namespace Team1_SmartBank.API.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        // ✅ ADD ROLE
        [Required]
        public string Role { get; set; }   // Admin / Manager / Customer

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}