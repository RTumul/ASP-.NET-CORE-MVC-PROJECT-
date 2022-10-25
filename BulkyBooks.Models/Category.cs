using System.ComponentModel.DataAnnotations;

namespace BulkyBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required, Display(Name ="Category Name")]
        public string ProductName { get; set; }
        [Required, Display(Name ="Category Price")]
        public float ProductPrice { get; set; }
    }
}
