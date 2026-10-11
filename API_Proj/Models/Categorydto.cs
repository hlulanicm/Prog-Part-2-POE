using System.ComponentModel.DataAnnotations;

namespace API_proj.Models
{
    public class CategoryDto
    {
        [Required, StringLength(50)]
        public string CategoryType { get; set; } = string.Empty;

        [StringLength(500)]///setting description the length to 500 
        public string? Description { get; set; }

        [Required, StringLength(50)]//setting  the Name length to 50

    }

}
