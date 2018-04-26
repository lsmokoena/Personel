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
    public class CategoryController : Controller
    {
        private ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private CategoriesViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Category, bool>> filterExpression = c => c.Name.ToUpper().Contains(filter.ToUpper())
                                                                    || c.Description.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Category, string> orderingExpression = Util.OrderByHelper<Category>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = CategoryRepository.GetCount(filterExpression, null);
            var pager = new Pager("Category", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = CategoryRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new CategoriesViewModel()
            {
                Title = "Categories",
                Heading = "Categories",
                Categories = filteredIndustries.Select(c => new CategoryViewDto()
                {
                    ID = c.id,
                    Name = c.Name,
                    Description = c.Description
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

        private CategoriesViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
