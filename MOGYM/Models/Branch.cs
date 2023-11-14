using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class BranchModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Zip Code is required")]
        public string? ZipCode { get; set; }
        [Required]
        public string? Location { get; set; }
    }
}
