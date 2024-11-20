using System.ComponentModel.DataAnnotations;

namespace PasswordHashingDemo.DTOs
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username shoud be in between 5 to 20 characters")]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage ="Password must be in 5 to 10 characters" )]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
