using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private IRepository repository;
        public CommentController(IRepository repo)
        {
            repository = repo;
        }
        // GET: Comment
        public ActionResult List(int id)
        {
            var comments = repository.Comments.Where(x => x.PersonId == id).OrderBy(x => x.Date);
            var model = new CommentViewModel {Comments = comments, PersonId = id};
            return PartialView(model);
        }


        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            try
            {
                // TODO: Add insert logic here
                repository.SaveComment(comment);
                return RedirectToAction("List", "Person");
            }
            catch
            {
                return View();
            }
        }
    }
}
