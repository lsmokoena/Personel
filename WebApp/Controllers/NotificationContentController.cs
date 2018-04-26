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
    public class NotificationContentController : Controller
    {
        private INotificationContentRepository NotificationContentRepository;

        public NotificationContentController(INotificationContentRepository notificationContentRepository)
        {
            NotificationContentRepository = notificationContentRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private NotificationsContentViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<NotificationContent, bool>> filterExpression = n => n.Subject.ToUpper().Contains(filter.ToUpper())
                                                                                || n.Body.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<NotificationContent, string> orderingExpression = Util.OrderByHelper<NotificationContent>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = NotificationContentRepository.GetCount(filterExpression, null);
            var pager = new Pager("NotificationContent", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = NotificationContentRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new NotificationsContentViewModel()
            {
                Title = "Notification Content",
                Heading = "Notification Content",
                NotificationContents = filteredIndustries.Select(n => new NotificationContentViewDto()
                {
                    ID = n.id,
                    Body = n.Body,
                    Subject = n.Subject
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

        private NotificationsContentViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
