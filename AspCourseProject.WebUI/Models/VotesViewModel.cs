using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Models
{
    public class VotesViewModel
    {
        public VoteResults Votes { get; set; }
        public string ReturnUrl { get; set; }
    }
}