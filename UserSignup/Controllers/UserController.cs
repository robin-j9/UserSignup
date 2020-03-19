using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<User> users = UserData.GetUsers();
            return View(users);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                UserData.Add(addUserViewModel.CreateUser());
                return Redirect("/User");
            }
            return View(addUserViewModel);
        }

        public IActionResult UserInfo(int id)
        {
            DisplayUserViewModel displayUserViewModel = new DisplayUserViewModel(id);
            
            return View(displayUserViewModel);
        }
    }
}
