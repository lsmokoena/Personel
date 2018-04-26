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
    public class CountryController : Controller
    {
        private ICountryRepository CountryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            CountryRepository = countryRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private CountriesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Country, bool>> filterExpression = c => c.Name.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Country, string> orderingExpression = Util.OrderByHelper<Country>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = CountryRepository.GetCount(filterExpression, null);
            var pager = new Pager("Country", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = CountryRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new CountriesViewModel()
            {
                Title = "Country",
                Heading = "Country",
                Countries = filteredIndustries.Select(c => new CountryViewDto()
                {
                    ID = c.id,
                    Name = c.Name
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

        private CountriesViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
