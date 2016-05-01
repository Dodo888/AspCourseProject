using System;
using System.Linq;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;
using AspCourseProject.WebUI.Helpers;
using AspCourseProject.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace AspCourseProject.WebUI.Controllers
{
    public class VoteController : Controller
    {
        private IRepository repository;
        private IUserProvider UserProvider;
        private IWeekProvider WeekProvider;

        public VoteController(IRepository repo, IUserProvider userProvider, IWeekProvider weekProvider)
        {
            repository = repo;
            UserProvider = userProvider;
            WeekProvider = weekProvider;
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
        public ViewResult Checkout(VoteResults votes)
        {
            var userName = UserProvider.GetUserName(this);
            var currentWeek = WeekProvider.GetWeek();
            if (repository.Votes.Any(x => x.Week == currentWeek && x.UserName == userName))
            {
                return View(false);
            }
            repository.SaveVote(new Vote { UserName = userName, Week = currentWeek });
            var voteId = repository.Votes.FirstOrDefault(x => x.Week == currentWeek && x.UserName == userName).VoteId;
            foreach (var vote in votes.Votes)
            {
                repository.SaveVoteItem(new VoteItem() {PersonId = vote.PersonId, VoteId = voteId});
            }
            return View(true);
        }
    }
}