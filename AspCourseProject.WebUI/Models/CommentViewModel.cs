using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Models
{
    public class CommentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public IEnumerable<Comment> Comments { get; set; }
        public int PersonId { get; set; }
    }
}