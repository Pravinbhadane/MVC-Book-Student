using System.ComponentModel.DataAnnotations;

namespace MVC_Book.Models
{
    public class Book
    {
        [Key] // to define this is PK col in DB
        [ScaffoldColumn(false)] // becoz this is identity col , no need to display on form
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Author { get; set; }

        [ScaffoldColumn(false)]
        public int isActive { get; set; }

    }
}
