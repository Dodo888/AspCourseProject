using System.Linq;
using System.Web.Mvc;
using AspCourseProject.Domain;
using AspCourseProject.Domain.Entities;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class VoteController : Controller
    {
        private IPersonRepository repository;

        public VoteController(IPersonRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddVote(VoteResults votes, int personId, string returnUrl)
        {
            Person person = repository.Table.FirstOrDefault(p => p.PersonId == personId);
            if (person != null)
            {
               votes.AddVote(person);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveVote(VoteResults votes, int personId, string returnUrl)
        {
            Person person = repository.Table.FirstOrDefault(p => p.PersonId == personId);
            if (person != null)
            {
                votes.RemoveVote(person);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        // GET: Vote
        public ViewResult Index (VoteResults votes, string returnUrl)
        {
            return View(new VotesViewModel
            {
                Votes = votes,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(VoteResults votes)
        {
            return PartialView(votes);
        }

        [Authorize]
        public ViewResult Checkout()
        {
            return View();
        }
    }
}