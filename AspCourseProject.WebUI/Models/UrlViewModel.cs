using System.Web.Mvc;

namespace AspCourseProject.WebUI.Models
{
    public class UrlViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string CurrentCategory { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CurrentStatus { get; set; }

        public string SubName { get; set; }
    }
}