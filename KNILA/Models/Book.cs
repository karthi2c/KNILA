using System.ComponentModel.DataAnnotations;

namespace KNILA.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(25)]
        public string AuthorLastName { get; set; }

        [Required]
        [MaxLength(25)]
        public string AuthorFirstName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
