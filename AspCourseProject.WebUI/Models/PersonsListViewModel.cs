using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;
using SportsStore.WebUI.Models;

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

        public string SubName { get; set; }
    }
}