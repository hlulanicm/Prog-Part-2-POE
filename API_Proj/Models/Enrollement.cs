using System.ComponentModel.DataAnnotations;

namespace API_Proj.Models
{
    public class Enrollement
    {
        [Key]
        public int EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ParticipantID { get; set; }
        public int CategoryID { get; set; }
        public string Status { get; set; }
        public string? TargetAudience { get; set; }
    }
}