
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = "User";
        [NotMapped]
        public string AccessToken { get; set; }
        //public RoleGroup Role { get; set; }

    }
}
