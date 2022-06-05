using System.ComponentModel.DataAnnotations;
using Tickect_System_MVC.Enums;

namespace Tickect_System_MVC.Models
{
    public class UserModel : BaseModel
    {
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter CPF")]
        public string CPFNumber { get; set; }
        [Required(ErrorMessage = "Enter user profile")]
        public ProfileType UserType { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }


    }
}