using System.ComponentModel.DataAnnotations;

namespace Fixie.Models
{
    public class SignupViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}