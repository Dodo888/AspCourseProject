using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public RedirectToRouteResult AddVote(int personId, string returnUrl)
        {
            Person person = repository.Table.FirstOrDefault(p => p.PersonId == personId);
            if (person != null)
            {
                GetVotes().AddVote(person);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveVote(int personId, string returnUrl)
        {
            Person person = repository.Table.FirstOrDefault(p => p.PersonId == personId);
            if (person != null)
            {
                GetVotes().RemoveVote(person);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private VoteResults GetVotes()
        {
            var votes = (VoteResults) Session["Votes"];
            if (votes == null)
            {
                votes = new VoteResults();
                Session["Votes"] = votes;
            }
            return votes;
        }

        // GET: Vote
        public ViewResult Index (string returnUrl)
        {
            return View(new VotesViewModel
            {
                Votes = GetVotes(),
                ReturnUrl = returnUrl
            });
        }
    }
}