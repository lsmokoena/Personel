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
    public class AddressController : Controller
    {
        private IAddressRepository AddressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            AddressRepository = addressRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private AddressesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Address, bool>> filterExpression = a => a.Apartment.ToUpper().Contains(filter.ToUpper())
                                                                    || a.City.ToUpper().Contains(filter.ToUpper())
                                                                    || a.Street.ToUpper().Contains(filter.ToUpper())
                                                                    || a.Suburb.ToUpper().Contains(filter.ToUpper())
                                                                    || a.PostalCode.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Address, string> orderingExpression = Util.OrderByHelper<Address>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = AddressRepository.GetCount(filterExpression, null);
            var pager = new Pager("Address", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = AddressRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new AddressesViewModel()
            {
                Title = "Addresses",
                Heading = "Addresses",
                Addresses = filteredIndustries.Select(a => new AddressViewDto()
                {
                    ID = a.id,
                    Apartment = a.Apartment,
                    City = a.City,
                    Street = a.Street,
                    Suburb = a.Suburb,
                    PostalCode = a.PostalCode
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

        private AddressesViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
