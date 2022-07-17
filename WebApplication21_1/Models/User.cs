using Microsoft.AspNetCore.Identity;

namespace WebApplication21_1.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
