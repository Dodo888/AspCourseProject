using System;
using System.Web.Mvc;

namespace AspCourseProject.Domain.Entities
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }
    }
}