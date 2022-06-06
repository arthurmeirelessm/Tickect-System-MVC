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
                    _userRepository.CreateUserinDataBase(user);
                    TempData["MessageSuccess"] = "User created";
                    return View("Index");
                }
                TempData["MessageFailed"] = $"Ops, user not was created.";
                return View("Index");
            }
            catch (System.Exception error)
            {
                TempData["MessageFailedForError"] = error.Message;
                return View("Index");
            }

        }
    }
}
