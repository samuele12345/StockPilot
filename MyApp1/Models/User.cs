using Microsoft.AspNetCore.Identity;

namespace MyApp1.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}
