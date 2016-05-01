using System.Collections.Generic;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Models
{
    public class PersonsListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public IEnumerable<Person> Persons { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CurrentCategory { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CurrentStatus { get; set; }

        [HiddenInput(DisplayValue = false)]
        public PagingInfo PagingInfo { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool IsVoted { get; set; }

        public string SubName { get; set; }
    }
}