using System.ComponentModel.DataAnnotations;

namespace BulckyBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float ProductPrice { get; set; }
    }
}
