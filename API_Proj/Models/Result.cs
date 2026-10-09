using System.ComponentModel.DataAnnotations;

namespace API_Proj.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }
        public int EnrollmentID { get; set; }
        public int? Position { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public TimeSpan? StartTime { get; set; }
    }
}