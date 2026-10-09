using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Proj.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int EventID { get; set; }

        [Column("Category")]
        public string CategoryType { get; set; }

        public string? Description { get; set; }
        public string Name { get; set; }
        public decimal? Distance { get; set; }
        public int MaxParticipants { get; set; }
    }
}