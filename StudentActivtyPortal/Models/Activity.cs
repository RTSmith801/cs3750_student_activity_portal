using System;

namespace StudentActivityPortal.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime ActivityDate { get; set; }
    }
}