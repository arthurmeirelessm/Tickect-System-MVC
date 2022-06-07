using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickect_System_MVC.Helpers;
using Tickect_System_MVC.Models;
using Tickect_System_MVC.Repository;

namespace Tickect_System_MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISessionUser _session;

        public UserController(IUserRepository userRepository, ISessionUser session)
        {
            _userRepository = userRepository;
            _session = session;
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
                    var nameLength = user.Name.Length;
                    var cpfLength = user.CPFNumber.Length;
                    if (nameLength > 4 && nameLength < 30)
                    {
                        if (cpfLength == 11)
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
