using System.ComponentModel.DataAnnotations;

namespace restApi.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}