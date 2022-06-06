using Microsoft.AspNetCore.Mvc;
using Tickect_System_MVC.Models;
using Tickect_System_MVC.Repository;

namespace Tickect_System_MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
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
                            return View("Index", "Login");
                        }
                        else
                        {
                            TempData["MessageFailedForCpf"] = "Invalid cpf";
                            return View("Index");
                        }
                    }
                    TempData["MessageFailedForCharacter"] = "Number of characters in the name must be between 4 and 30";
                    return View("Index");
                }
                return View("Index");
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = error.Message;
                return View("Index", "Login");
            }

        }
    }
}
