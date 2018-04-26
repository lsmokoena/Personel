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
    public class BankController : Controller
    {
        private IBankRepository BankRepository;

        public BankController(IBankRepository bankRepository)
        {
            BankRepository = bankRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private BanksViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Bank, bool>> filterExpression = b => b.Name.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Bank, string> orderingExpression = Util.OrderByHelper<Bank>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = BankRepository.GetCount(filterExpression, null);
            var pager = new Pager("Bank", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = BankRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new BanksViewModel()
            {
                Title = "Banks",
                Heading = "Banks",
                Banks = filteredIndustries.Select(b => new BankViewDto()
                {
                    ID = b.id,
                    Name = b.Name
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

        private BanksViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
