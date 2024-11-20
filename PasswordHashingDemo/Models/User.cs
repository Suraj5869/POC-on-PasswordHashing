using System.ComponentModel.DataAnnotations;

namespace PasswordHashingDemo.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =5, ErrorMessage ="Username shoud be in between 5 to 20 characters")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
