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
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Personel.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository UserRepository;
        private IConfigurationRoot ConfigRoot;

        public UserController(IUserRepository userRepository, IConfigurationRoot configRoot)
        {
            UserRepository = userRepository;
            ConfigRoot = configRoot;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            UsersViewModel viewModel = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(viewModel);
        }

        private UsersViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            //define the list filtering
            filter = filter ?? ""; 
            Expression<Func<User, bool>> filterExpression = u => u.LastName.ToUpper().Contains(filter.ToUpper()) 
                                                              || u.FirstName.ToUpper().Contains(filter.ToUpper())
                                                              || u.Email.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<User, string> orderingExpression = Util.OrderByHelper<User>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredUsersCount = UserRepository.GetCount(filterExpression);
            var pager = new Pager("Users", "Index", filteredUsersCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredUsers = UserRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new UsersViewModel()
            {
                Title = "Users",
                Users = filteredUsers.Select(u => new UserViewDto()
                {
                    ID = u.id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    TelephoneNumber = u.TelephoneNumber
                }).ToList(),
                Pager = pager,
            };
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = getEditModel(id);
            return View(model);
        }
        
        private UsersViewModel getEditModel(int userId)
        {
            //check if userid exists if it doesn't assume that we adding a new user
            User user = null;
            user = UserRepository.GetSingle(u => u.id == userId);
            if (user == null)
            {
                user = new DAL.Models.User();
                user.Active = false;
            }

            var users = new List<UserViewDto>();
            users.Add(new UserViewDto()
            {
                ID = user.id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                TelephoneNumber = user.TelephoneNumber,
                Active = user.Active
            });

            var model = new UsersViewModel()
            {
                Title = (userId == 0) ? "New User" : "Edit User \'"+user.FirstName+" "+user.LastName+"\'"
            };

            return model;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewDto user)
        {
            if (!ModelState.IsValid)
            {
                this.AddErrorMessageToast("Error! unable to save the user.");
                var editModel = getEditModel(user.ID);
                return View(editModel);
            }

            User dbUser = null;

            if (user.ID != 0)
                dbUser = UserRepository.GetSingle(c => c.id == user.ID);
            else
            {
                dbUser = new DAL.Models.User();

                //Generate forgoten password token for password reset for new user
                dbUser.ForgottenPasswordToken = DAL.Util.PasswordHelper.GeneratePassword();
            }

            dbUser.Active = user.Active;
            dbUser.Email = user.Email;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Name = user.Name;
            dbUser.TelephoneNumber = user.TelephoneNumber;
            
            if (user.ID != 0)
                UserRepository.Update(dbUser);
            else
            {
                UserRepository.Add(dbUser);

                //Send Email
                var mailHelper = new EmailHelper(ConfigRoot);
                var reponse = await mailHelper.SendWelcomeEmail(dbUser.ForgottenPasswordToken, dbUser.Email, dbUser.FirstName, Request.Host.Value);
                
                this.AddSuccessMessageToast("User added successfully.");
                return RedirectToAction("Index", "Users");
            }

            if(user.ID == 0){
                this.AddSuccessMessageToast("User added successfully.");
            }else{
                this.AddSuccessMessageToast("User updated successfully.");
            }
            return RedirectToAction("Index", "Users");
        }
    }
}
