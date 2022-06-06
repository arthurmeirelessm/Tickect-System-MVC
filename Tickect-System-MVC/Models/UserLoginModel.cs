using System.ComponentModel.DataAnnotations;

namespace Tickect_System_MVC.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
    }
}
