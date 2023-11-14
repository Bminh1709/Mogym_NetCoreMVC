using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
