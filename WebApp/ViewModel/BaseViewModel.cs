using Personel.Models;
namespace Personel.ViewModel
{
    public class BaseViewModel
    {
        public string Title;
        public string Heading;

        /// <summary>
        /// our custom pager control to use for any lists 
        /// </summary>
        public Pager Pager { get; set; }
    }
}