using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cAthlet.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? FirstName { get; set; }     
        public string? LastName { get; set; }    
        public int? Age { get; set; }             
        public float? Height { get; set; }      
        public float? Weight { get; set; }

        public string ProfileImage { get; set; } = "kater0.png";
    }
}
