using System.Collections.Generic;

namespace AspCourseProject.WebUI.Models
{
    public class MenuCategoryViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string CurrentStatus { get; set; }
    }
}