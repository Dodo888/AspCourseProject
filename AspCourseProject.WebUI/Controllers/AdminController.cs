using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;

namespace AspCourseProject.WebUI.Controllers
{
    [Authorize(Users = "darkdodo888@gmail.com")]
    public class AdminController : Controller
    {
        private IRepository repository;
        public AdminController(IRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Table);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Table.FirstOrDefault(x => x.PersonId == id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();  
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                // TODO: Add insert logic here
                repository.SavePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(person);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Table.FirstOrDefault(x => x.PersonId == id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person, HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add update logic here
                person.ImageMimeType = image.ContentType;
                person.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(person.ImageData, 0, image.ContentLength);
                repository.SavePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(person);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Table.FirstOrDefault(x => x.PersonId == id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                // TODO: Add delete logic here
                repository.RemovePerson(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(person);
            }
        }
    }
}
