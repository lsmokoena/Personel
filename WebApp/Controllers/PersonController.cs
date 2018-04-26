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
    public class PersonController : Controller
    {
        private IPersonRepository PersonRepository;

        public PersonController(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private PersonsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Person, bool>> filterExpression = n => n.FirstName.ToUpper().Contains(filter.ToUpper())
                                                                   || n.LastName.ToUpper().Contains(filter.ToUpper())
                                                                   || n.IdNumber.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Person, string> orderingExpression = Util.OrderByHelper<Person>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = PersonRepository.GetCount(filterExpression, null);
            var pager = new Pager("Person", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = PersonRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new PersonsViewModel()
            {
                Title = "Person",
                Heading = "Person",
                Persons = filteredIndustries.Select(n => new PersonViewDto()
                {
                    ID = n.id,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    IdNumber = n.IdNumber,
                    PassportNumber = n.PassportNumber,
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

        private PersonsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
