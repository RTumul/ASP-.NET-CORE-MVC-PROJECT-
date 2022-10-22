using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBooks.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required,EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        
        [Required]
        
       
        public string UserType { get; set; } = "User";

    }
}
