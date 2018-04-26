using Microsoft.AspNetCore.Mvc;
using Personel.ViewModel;

namespace Personel.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                Title = "Something Went Wrong",
                Heading = "Something Went Wrong",
            });
        }

        [HttpGet]
        public IActionResult Error404()
        {
            return View(new BaseViewModel()
            {
                Title = "Error",
                Heading = "Error",
            });
        }
        
        [Route("Error/{code:int}")]
        public IActionResult Error(int code)
        {
            if (code == 404)
                return RedirectToAction("Error404");
            else
                return RedirectToAction("Index");
        }
    }
}
