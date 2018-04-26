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
    public class ReviewController : Controller
    {
        private IReviewRepository ReviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private ReviewsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Review, bool>> filterExpression = n => n.Level.ToString().ToUpper().Contains(filter.ToUpper())
                                                                  || n.Remark.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Review, string> orderingExpression = Util.OrderByHelper<Review>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = ReviewRepository.GetCount(filterExpression, null);
            var pager = new Pager("Review", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = ReviewRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new ReviewsViewModel()
            {
                Title = "Review",
                Heading = "Review",
                Reviews = filteredIndustries.Select(n => new ReviewViewDto()
                {
                    ID = n.id,
                    Level = n.Level,
                    Remark = n.Remark
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

        private ReviewsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
