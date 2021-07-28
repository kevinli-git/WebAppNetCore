using System.ComponentModel.DataAnnotations;

namespace WebAppNetCore.Models
{
    public class Account
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
