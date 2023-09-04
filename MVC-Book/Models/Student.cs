using System.ComponentModel.DataAnnotations;

namespace MVC_Book.Models
{
    public class Student
    {
        [Key] 
        [ScaffoldColumn(false)]
        public int RollId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]

        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
