using DAL.Interface;
using DAL.Models;
using Personel.Models;
using Personel.ViewDto;
using Personel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using Personel.Extensions.ControllerToastExtensions;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Personel.Util;
using Microsoft.Extensions.Configuration;

namespace Personel.Controllers
{
    public class RegisterController : Controller
    {
        private IUserRepository UserRepository;

        public RegisterController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new RegisterViewModel() {
                Title = "Register",
                Heading = "Register",
                Email = "",
                FirstName = "",
                LastName = "",
                Password = ""
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(RegisterViewModel register)
        {
            var user = UserRepository.GetSingle(u => u.Email == register.Email);

            if (user != null)
            {
                //error! user with this email already exist
            }
            else
                user = new User();

            user.FirstName = register.FirstName;
            user.LastName = register.FirstName + " " + register.LastName;
            user.TelephoneNumber = register.TelephoneNumber;
            user.Name = register.LastName;
            user.Email = register.Email;
            user.ClearPassword = register.Password;
            user.Active = false;
            user.VerifyAccountToken = DAL.Util.PasswordHelper.GeneratePassword();
            user.DateCreated = DateTime.Now;

            UserRepository.Add(user);

            //send email
            //redirect to welcome page with message email sent,  verify account

            return RedirectToAction("Index", "Users");
        }
    }
}
