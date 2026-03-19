using System;
using System.ComponentModel.DataAnnotations;

namespace StudentActivityPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}