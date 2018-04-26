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
    public class AccountTypeController : Controller
    {
        private IAccountTypeRepository AccountTypeRepository;

        public AccountTypeController(IAccountTypeRepository accountTypeRepository)
        {
            AccountTypeRepository = accountTypeRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private AccountTypesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<AccountType, bool>> filterExpression = a => a.Name.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<AccountType, string> orderingExpression = Util.OrderByHelper<AccountType>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = AccountTypeRepository.GetCount(filterExpression, null);
            var pager = new Pager("AccountType", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = AccountTypeRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new AccountTypesViewModel()
            {
                Title = "AccountType",
                Heading = "AccountType",
                AccountTypes = filteredIndustries.Select(a => new AccountTypeViewDto()
                {
                    ID = a.id,
                    Name = a.Name
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

        private AccountTypesViewModel getEditModel(int id)
        {


            return null;
        }
    }
}
