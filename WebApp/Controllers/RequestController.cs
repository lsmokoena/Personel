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
    public class RequestController : Controller
    {
        private IRequestRepository RequestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            RequestRepository = requestRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private RequestsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Request, bool>> filterExpression = n => n.Note.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Request, string> orderingExpression = Util.OrderByHelper<Request>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = RequestRepository.GetCount(filterExpression, null);
            var pager = new Pager("Request", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = RequestRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new RequestsViewModel()
            {
                Title = "Request",
                Heading = "Requests",
                Requests = filteredIndustries.Select(n => new RequestViewDto()
                {
                    ID = n.id,
                    Note = n.Note
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

        private RequestsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
