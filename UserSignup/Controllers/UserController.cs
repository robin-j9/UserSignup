using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        private static User savedUser;
        private static bool nameLengthValid = true;
        private static bool nameLettersOnly = true;
        private static bool passwordsMatch = true;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.users = UserData.GetUsers();
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.passwordsMatch = passwordsMatch;
            ViewBag.nameLengthValid = nameLengthValid;
            ViewBag.nameLettersOnly = nameLettersOnly;

            if(savedUser != null)
            {
                ViewBag.savedUser = savedUser;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user, string verify)
        {
            ViewBag.user = user;
            savedUser = user;

            nameLettersOnly = user.NameContainsOnlyLetters(user);
            nameLengthValid = user.NameIsCorrectLength(user);
            passwordsMatch = verify == user.Password;

            if (!nameLettersOnly || !nameLengthValid || !passwordsMatch)
            {
                return Redirect("Add");
            }
            else
            {
                UserData.Add(user);
                ViewBag.users = UserData.GetUsers();
                //return View("../Home/Index");
                return View("Index");
            }
        }

        public IActionResult UserInfo(int id)
        {
            ViewBag.user = UserData.GetUserById(id);
            return View();
        }
    }
}
