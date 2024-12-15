
using System.ComponentModel.DataAnnotations;


namespace Domain.Dto.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
