using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.Models
{
    public class Pager
    {
        public Pager(string controller, string action, int totalItemsCount, int? pageNumber, int pageSize = 12, string filter = "", string orderBy = "")
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItemsCount / (decimal)pageSize);
            var currentPage = pageNumber != null ? (int)pageNumber : 1;

            //fix invalid current page
            if (currentPage > totalPages)
                currentPage = totalPages;
            else if (currentPage <= 1)
                currentPage = 1;

            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItemsCount;

            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            Controller = controller;
            Action = action;
            Filter = filter;
            OrderBy = orderBy;
        }

        public string Controller { get; set; }
        public string Action { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public string Filter { get; set; }
        public string OrderBy { get; set; }
    }
}
