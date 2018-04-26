using DAL.Interface;
using DAL.Repository;
using Personel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personel.ViewDto;
using DAL.Models;
using System.Linq.Expressions;
using Personel.Models;

namespace Personel.Controllers
{
    public class NotificationController : Controller
    {
        private INotificationRepository NotificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            NotificationRepository = notificationRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private NotificationsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Notification, bool>> filterExpression = n => n.NotificationTypeId.ToString().ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Notification, string> orderingExpression = Util.OrderByHelper<Notification>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = NotificationRepository.GetCount(filterExpression, null);
            var pager = new Pager("Notification", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = NotificationRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new NotificationsViewModel()
            {
                Title = "Notification",
                Heading = "Notification",
                Notifications = filteredIndustries.Select(n => new NotificationViewDto()
                {
                    ID = n.id,
                    NotificationTypeId = n.NotificationTypeId,
                    PersonId = n.PersonId,
                    UserId = n.UserId
                }).ToList(),
                Pager = pager
            };
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = getEditModel(id);
            return View(model);
        }

        private NotificationsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
