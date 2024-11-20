using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Data
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
            
        }
    }
}
