using System.ComponentModel.DataAnnotations;

namespace PasswordHashingDemo.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage ="Username shoud be in 5 to 20 character")]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be in 5 to 10 characters")]
        public string Password { get; set; }
    }
}
