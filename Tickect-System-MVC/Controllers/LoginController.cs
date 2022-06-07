using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tickect_System_MVC.Helpers;
using Tickect_System_MVC.Models;
using Tickect_System_MVC.Repository;

namespace Tickect_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionUser _session;

        public LoginController(IUserRepository userRepository, ISessionUser session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
           
            return View();
        }
      

        public IActionResult EnterLoginInApplication(UserLoginModel userLoginModel)
        {
            try
            {
                var comparateLogin = _userRepository.LoginValidation(userLoginModel);
                if (comparateLogin is not null)
                {
                    _session.CreateSessionOfUser(user);
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = error.Message;
                return View("Index");
            }
        }
    }
}
