using System;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Models;
using Personel.ViewDto;
using Personel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Personel.Extensions.ControllerToastExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Personel.Util;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Personel.Controllers
{
    public class AccountController : Controller
    {
        private const string AUTH_COOKIE_NAME = "auth";
        private IUserRepository UserRepository;
        private IConfigurationRoot ConfigRoot;

        public AccountController(IUserRepository userRepository, IConfigurationRoot configRoot)
        {
            UserRepository = userRepository;
            ConfigRoot = configRoot;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            SignOut();

            var model = new LoginViewModel()
            {
                Login = new LoginViewDto()
                {
                    Username = "",
                    Password = ""
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewDto loginDto, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                this.AddErrorMessageToast("Invalid username or password");
                return View(new LoginViewModel { Login = loginDto });
            }

            string hashedPassword = DAL.Util.PasswordHelper.GetStringHash(loginDto.Password);
            var userAttemptingToLogin = UserRepository.GetSingle(u => u.Active == true && u.Email.ToUpper() == loginDto.Username.ToUpper() && u.HashedPassword == hashedPassword);

            if (userAttemptingToLogin == null)
            {
                this.AddErrorMessageToast("Invalid username or password");
                return View(new LoginViewModel { Login = loginDto });
            }

            SignInUser(userAttemptingToLogin);

            //send user back via return url
            if (returnUrl == null)
                return RedirectToAction("Index", "Welcome");
            else
                return Redirect(returnUrl);
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

        [HttpGet]
        public IActionResult Logout()
        {
            SignOut();
            return RedirectToAction("Index", "Users");
        }

        private void SignOut()
        {
            HttpContext.Authentication.SignOutAsync(AUTH_COOKIE_NAME).Wait();
        }

        [HttpGet]
        public IActionResult ResetPassword(string forgottenPasswordToken)
        {
            var model = new ResetPasswordViewModel()
            {
                Password = "",
                ConfirmPassword = ""
            };

            if (!string.IsNullOrWhiteSpace(forgottenPasswordToken))
            {
                var user = UserRepository.GetSingle(u => u.Active == true && u.ForgottenPasswordToken == forgottenPasswordToken);
                if (user == null)
                {
                    this.AddErrorMessageToast("Invalid password reset token");
                    return RedirectToAction("Login");
                }

                //to reset a password the user needs to be signed in
                SignInUser(user);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ResetPassword(ResetPasswordViewDto resetDto, string returnUrl = "")
        {
            if (string.IsNullOrEmpty(resetDto.Password))
            {
                this.AddErrorMessageToast("Password cannot have a length of 0");
                return RedirectToAction(returnUrl);
            }
            
            if (resetDto.Password != resetDto.ConfirmPassword)
            {
                var model = new ResetPasswordViewModel()
                {
                    Password = resetDto.Password,
                    ConfirmPassword = resetDto.ConfirmPassword
                };
                
                this.AddErrorMessageToast("Password and confirmation do not match");
                return View(model);
            }
            
            int userID = int.Parse(HttpContext.User.FindFirst("ID").Value ?? "0");
            var user = UserRepository.GetSingle(u => u.id == userID);
            user.ClearPassword = resetDto.Password;
            user.HashedPassword = DAL.Util.PasswordHelper.GetStringHash(user.ClearPassword);
            UserRepository.Update(user);

            SignOut();
            this.AddSuccessMessageToast("Password reset");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                SignInUser(user);
                return RedirectToAction(returnUrl);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var model = new ForgotPasswordViewModel()
            {
                Email = ""
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewDto forgotDto)
        {
            var user = UserRepository.GetSingle(u => u.Active == true && u.Email.ToUpper() == forgotDto.Email.ToUpper());
            if (user == null)
            {
                this.AddErrorMessageToast("Invalid email address");
                var model = new ForgotPasswordViewModel()
                {
                    Email = forgotDto.Email
                };

                return View(model);
            }
            user.ForgottenPasswordToken = DAL.Util.PasswordHelper.GeneratePassword();
            UserRepository.Update(user);

            var mailHelper = new EmailHelper(ConfigRoot);
            var reponse = await mailHelper.SendMail(user.ForgottenPasswordToken, user.Email, Request.Host.Value);

            this.AddSuccessMessageToast("Password reset sent to provided email address");
            return RedirectToAction("Login");
        }
    }
}
