using System.ComponentModel.DataAnnotations;

namespace API_Proj.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public int OrganiserID { get; set; }
        public int? CategoryID { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string? TargetAudience { get; set; }
    }
}