using DAL.Interface;
using DAL.Models;
using Personel.ViewDto;
using Personel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Personel.Extensions.ControllerToastExtensions;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;

namespace Personel.Controllers
{
    public class CompleteProfileController : Controller
    {
        private const string AUTH_COOKIE_NAME = "auth";
        private IUserRepository UserRepository;
        private IBankRepository BankRepository;
        private IAccountTypeRepository AccountTypeRepository;

        public CompleteProfileController(IUserRepository userRepository, IBankRepository bankRepository, IAccountTypeRepository accountTypeRepository)
        {
            UserRepository = userRepository;
            BankRepository = bankRepository;
            AccountTypeRepository = accountTypeRepository;
        }

        [HttpGet]
        private IActionResult Index()
        {
            var viewModel = new CompleteRegistrationViewModel() {
                UserId = 1,
                Title = "Complete registration",
                Heading = "Complete registration",
                Banks = BankRepository.GetAll().Select(b => new BankViewDto()
                {
                    ID = b.id,
                    Name = b.Name,
                }).ToList(),
                AccountTypes = AccountTypeRepository.GetAll().Select(a => new AccountTypeViewDto() {
                    ID = a.id,
                    Name = a.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult VerifyAccount(string verifyAccountToken)
        {
            if (string.IsNullOrEmpty(verifyAccountToken))
            {
                //error message
                return RedirectToAction("Index", "Login");
            }

            var user = UserRepository.GetSingle(u => u.VerifyAccountToken == verifyAccountToken);

            if (user == null)
            {
                //error user does not exist
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //if (user.Active == true)
                //{
                //    SignInUser(user);
                //    this.AddErrorMessageToast("Your account is already active");
                //    return RedirectToAction("Index", "History");
                //    //return RedirectToAction("Index", "Home");
                //}

                user.Active = true;
                UserRepository.Update(user);
            }

            return RedirectToAction("CompleteRegistration", "CompleteProfile", new { id = user.id });
        }

        [HttpGet]
        public IActionResult CompleteRegistration(int id)
        {
            var viewModel = new CompleteRegistrationViewModel()
            {
                UserId = id,
                Title = "Complete registration",
                Heading = "Complete registration",
                Banks = BankRepository.GetAll().Select(b => new BankViewDto()
                {
                    ID = b.id,
                    Name = b.Name,
                }).ToList(),
                AccountTypes = AccountTypeRepository.GetAll().Select(a => new AccountTypeViewDto()
                {
                    ID = a.id,
                    Name = a.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CompleteRegistration(CompleteRegistrationViewModel completeReg)
        {
            var user = UserRepository.GetSingle(u => u.id == completeReg.UserId);
            user.Active = true;

            UserRepository.Update(user);

            //save successfull message
            return RedirectToAction("Index", "CompleteProfile");
        }

        private void SignInUser(User userAttemptingToLogin)
        {
            var claimsList = new List<Claim>();

            Claim id = new Claim("ID", userAttemptingToLogin.id.ToString());
            Claim name = new Claim("Name", userAttemptingToLogin.FirstName.ToString());
            Claim type = new Claim("Type", "Admin");

            claimsList.Add(id);
            claimsList.Add(name);
            claimsList.Add(type);

            //TODO add all the functions owned by this user
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimsList, AUTH_COOKIE_NAME);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            //signout if you are already signed in
            HttpContext.Authentication.SignOutAsync(AUTH_COOKIE_NAME);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(1)
            };

            HttpContext.Authentication.SignInAsync(AUTH_COOKIE_NAME, principal, properties).Wait();
        }
    }
}
