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
    public class MessageTypeController : Controller
    {
        private IMessageTypeRepository MessageTypeRepository;

        public MessageTypeController(IMessageTypeRepository messageTypeRepository)
        {
            MessageTypeRepository = messageTypeRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private MessageTypesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<MessageType, bool>> filterExpression = m => m.Type.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<MessageType, string> orderingExpression = Util.OrderByHelper<MessageType>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = MessageTypeRepository.GetCount(filterExpression, null);
            var pager = new Pager("MessageType", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = MessageTypeRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new MessageTypesViewModel()
            {
                Title = "MessageType",
                Heading = "MessageType",
                MessageTypes = filteredIndustries.Select(m => new MessageTypeViewDto()
                {
                    ID = m.id,
                    Type = m.Type
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

        private MessageTypesViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
