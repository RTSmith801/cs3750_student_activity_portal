using System.ComponentModel.DataAnnotations;

namespace StudentActivityPortal.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string? Description { get; set; }

        [Display(Name = "Activity Date")]
        public DateTime ActivityDate { get; set; }

        public string? Location { get; set; }
    }
}