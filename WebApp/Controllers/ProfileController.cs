using DAL.Interface;
using DAL.Models;
using Personel.ViewDto;
using Personel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Personel.Extensions.ControllerToastExtensions;
using Microsoft.Extensions.Configuration;

namespace Personel.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserRepository UserRepository;
        private IBankRepository BankRepository;
        private IAccountTypeRepository AccountTypeRepository;
        private IConfigurationRoot ConfigRoot;

        public ProfileController(IUserRepository userRepository, IBankRepository bankRepository, IAccountTypeRepository accountTypeRepository, IConfigurationRoot configRoot)
        {
            UserRepository = userRepository;
            BankRepository = bankRepository;
            AccountTypeRepository = accountTypeRepository;

            ConfigRoot = configRoot;
        }
        
        [HttpGet]
        public IActionResult Edit()
        {
            var id = int.Parse(HttpContext.User.FindFirst("ID").Value);
            var model = getEditModel(id);
            return View(model);
        }

        private UsersViewModel getEditModel(int userId)
        {
            var user = UserRepository.GetSingle(u => u.id == userId);

            var model = new UsersViewModel()
            {
                Title = "Edit Profile",
            };

            return model;
        }

        [HttpPost]
        public IActionResult Edit(int userId, string firstName, string lastName, string telephoneNumber, int bankId, int accountTypeId, string accountNumber)
        {
            User dbUser = UserRepository.GetSingle(c => c.id == userId);

            dbUser.FirstName = firstName;
            dbUser.LastName = lastName;
            dbUser.TelephoneNumber = telephoneNumber;

            UserRepository.Update(dbUser);

            this.AddSuccessMessageToast("Profile saved successfully.");
            return RedirectToAction("Edit", "Profile");
        }
    }
}