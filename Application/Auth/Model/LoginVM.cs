using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Model
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}