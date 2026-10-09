using System.ComponentModel.DataAnnotations;

namespace API_Proj.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}