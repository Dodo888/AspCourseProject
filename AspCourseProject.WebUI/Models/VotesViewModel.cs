using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Models
{
    public class VotesViewModel
    {
        public VoteResults Votes { get; set; }
        public string ReturnUrl { get; set; }
    }
}