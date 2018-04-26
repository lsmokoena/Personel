using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Personel.Extensions.ControllerToastExtensions
{
    public static class ControllerToastExtensions
    {
        public static void AddErrorMessageToast(this Controller controller, string message)
        {
            controller.TempData.Add("ErrorMessage", message);
        }

        public static void AddInfoMessageToast(this Controller controller, string message)
        {
            controller.TempData.Add("InfoMessage", message);
        }

        public static void AddSuccessMessageToast(this Controller controller, string message)
        {
            controller.TempData.Add("SuccessMessage", message);
        }
    }
}
