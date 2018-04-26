using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using DAL.Interface;
using Personel.ViewDto;
using DAL.Models;
using Personel.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Personel
{
    public class SupportController : Controller
    {
        private ISupportRepository SupportRepository;

        public SupportController(ISupportRepository supportRepository)
        {
            SupportRepository = supportRepository;
        }

        public IActionResult Index()
        {
            var supports = new List<SupportViewDto>();
            supports.Add(new SupportViewDto()
            {
                ID = 0,
                CellNumber = "",
                Email = "",
                Message = "",
            });

            var viewModel = new SupportsViewModel() {
                Title = "Support",
                Heading = "Heading",
                Supports = supports
            };

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult RequestSupport(string email, string cellNumber, int subjectId, string message)
        {
            var supportTicket = new Support() {
                Active = true,
                CellNumber = cellNumber,
                DateCreated = DateTime.Now,
                Email = email,
                Message = message,
                SubjectId = subjectId
            };

            SupportRepository.Add(supportTicket);

            //Support ticket successfully logged message
            return RedirectToAction("Index", "Support");
        }

        [HttpGet]
        public IActionResult SupportResponse()
        {
            var supportTickects = SupportRepository.GetAll();

            var viewModel = supportTickects.Select(s => new SupportViewDto() {
                ID = s.id,
                CellNumber = s.CellNumber,
                Email = s.Email,
                IsActive = s.Active,
                Message = s.Message
            });

            return View(viewModel);
        }
    }
}
