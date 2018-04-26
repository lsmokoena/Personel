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
    public class LocationController : Controller
    {
        private ILocationRepository LocationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private LocationsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Location, bool>> filterExpression = c => c.MapLocation.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Location, string> orderingExpression = Util.OrderByHelper<Location>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = LocationRepository.GetCount(filterExpression, null);
            var pager = new Pager("Location", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = LocationRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new LocationsViewModel()
            {
                Title = "Location",
                Heading = "Location",
                Locations = filteredIndustries.Select(l => new LocationViewDto()
                {
                    ID = l.id,
                    Latitude = l.Latitude,
                    Longitude = l.Longitude,
                    MapLocation = l.MapLocation
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

        private LocationsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
