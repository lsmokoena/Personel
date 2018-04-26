using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class ReviewsViewModel : BaseViewModel
    {
        public ReviewsViewModel()
        {
            Reviews = new List<ReviewViewDto>();
        }

        public List<ReviewViewDto> Reviews { get; set; }
    }
}
