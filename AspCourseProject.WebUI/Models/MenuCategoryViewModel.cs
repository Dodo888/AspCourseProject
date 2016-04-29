using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspCourseProject.WebUI.Models
{
    public class MenuCategoryViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string CurrentStatus { get; set; }
    }
}