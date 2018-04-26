using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personel.ViewModel;

namespace Dream.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                Title = "Welcome",
                Heading = "Welcome",
            });
        }
    }
}
