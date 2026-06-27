using Microsoft.AspNetCore.Identity;

namespace MyApp1.Models
{
    public class UserM : IdentityUser
    {
        public string FullName { get; set; } = null!;

        // Navigation property: un utente può avere molti items
        public ICollection<Items> Items { get; set; } = new List<Items>();
    }
}
