using Microsoft.AspNetCore.Mvc;
using Tickect_System_MVC.Models;
using Tickect_System_MVC.Repository;

namespace Tickect_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nameAccepted = user.Name.Length;
                    var cpfAccepted = user.CPFNumber.Length;
                    if (nameAccepted > 4 && nameAccepted < 30)
                    {
                        if (cpfAccepted == 11)
                        {
                            _userRepository.CreateUserInDataBase(user);
                            TempData["MessageSuccess"] = "User created";
                            return View("Index");
                        }
                        else
                        {
                            TempData["MessageFailedForCpf"] = "Invalid cpf";
                            return View("RegisterUser");
                        }
                    }
                    TempData["MessageFailedForCharacter"] = "Number of characters in the name must be between 4 and 30";
                    return View("RegisterUser");
                }
                return View("RegisterUser");
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = error.Message;
                return View("Index");
            }

        }
    }
}
