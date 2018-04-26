using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Personel.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Personel.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                Title = "About",
                Heading = "About",
            });
        }
    }
}
