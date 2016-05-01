using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Models
{
    public class PersonView
    {
        public Person Person { get; set; }
        public bool IsVoted { get; set; }
    }
}