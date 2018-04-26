using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class CategoriesViewModel : BaseViewModel
    {
        public CategoriesViewModel()
        {
            Categories = new List<CategoryViewDto>();
        }

        public List<CategoryViewDto> Categories { get; set; }
    }
}
