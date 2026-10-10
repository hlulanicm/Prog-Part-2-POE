using System.ComponentModel.DataAnnotations;

namespace API_Proj.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        ///Id of the Organiser (User) who created the event.Will be Set by the server, never by the client.
        public int OrganiserID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;

        ///Distance in kilometres.
        [Range(0.1, 1000)]
        public double Distance { get; set; }

        /// Must be Run, Walk or Cycle
        [Required, RegularExpression("^(Run|Walk|Cycle)$",
            ErrorMessage = "EventType must be Run, Walk or Cycle.")]
        public string EventType { get; set; } = string.Empty;

        public string? TargetAudience { get; set; }
    }
}