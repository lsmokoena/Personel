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
    public class NotificationTypeController : Controller
    {
        private INotificationTypeRepository NotificationTypeRepository;

        public NotificationTypeController(INotificationTypeRepository notificationTypeRepository)
        {
            NotificationTypeRepository = notificationTypeRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private NotificationTypesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<NotificationType, bool>> filterExpression = n => n.Name.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<NotificationType, string> orderingExpression = Util.OrderByHelper<NotificationType>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = NotificationTypeRepository.GetCount(filterExpression, null);
            var pager = new Pager("NotificationType", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = NotificationTypeRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new NotificationTypesViewModel()
            {
                Title = "Notification Type",
                Heading = "Notification Type",
                NotificationTypes = filteredIndustries.Select(n => new NotificationTypeViewDto()
                {
                    ID = n.id,
                    Name = n.Name
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

        private NotificationTypesViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
