using System.ComponentModel.DataAnnotations;

namespace BulkyBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required, Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required, Display(Name ="Product Price")]
        public float ProductPrice { get; set; }
    }
}
