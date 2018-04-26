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
    public class SkillController : Controller
    {
        private ISkillRepository SkillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            SkillRepository = skillRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            var model = getIndexModel(pageNumber, pageSize, filter, orderBy);
            return View(model);
        }

        private SkillsViewModel getIndexModel(int pageNumber = 1, int pageSize = 10, string filter = "", string orderBy = "")
        {
            filter = filter ?? "";
            Expression<Func<Skill, bool>> filterExpression = n => n.Name.ToUpper().Contains(filter.ToUpper())
                                                                 || n.Description.ToUpper().Contains(filter.ToUpper());

            //define the ordering expression
            Func<Skill, string> orderingExpression = Util.OrderByHelper<Skill>.GetOrderByExpression(orderBy);

            //get configure the pager
            int filteredIndustriesCount = SkillRepository.GetCount(filterExpression, null);
            var pager = new Pager("Skill", "Index", filteredIndustriesCount, pageNumber, pageSize, filter, orderBy);

            //filter the users
            var filteredIndustries = SkillRepository.GetPagedList(filterExpression, orderingExpression, pager.CurrentPage, pager.PageSize);

            //build our model
            return new SkillsViewModel()
            {
                Title = "Skill",
                Heading = "Skill",
                Skills = filteredIndustries.Select(n => new SkillViewDto()
                {
                    ID = n.id,
                    Name = n.Name,
                    Description = n.Description
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

        private SkillsViewModel getEditModel(int id)
        {
            return null;
        }
    }
}
