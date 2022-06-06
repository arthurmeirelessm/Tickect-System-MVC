﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickect_System_MVC.Models;
using Tickect_System_MVC.Repository;

namespace Tickect_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;

        public LoginController(IUserRepository userRepository, ISession session)
        {
            _userRepository = userRepository;
            _session = session;
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
                             var createSession = _session.crea
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

        public IActionResult EnterLoginInApplication(UserLoginModel userLoginModel)
        {
            try
            {
                var comparateLogin = _userRepository.LoginValidation(userLoginModel);
                if (comparateLogin is not null)
                {
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
