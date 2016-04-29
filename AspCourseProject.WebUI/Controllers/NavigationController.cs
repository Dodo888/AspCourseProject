using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspCourseProject.Domain;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class NavigationController: Controller
    {
        private IPersonRepository repository;
        public NavigationController(IPersonRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult MenuCategory(string category, string status)
        {
            var model = new MenuCategoryViewModel
            {
                Categories = repository.Table
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x),
                CurrentStatus = status
            };
            return PartialView(model);
        }
        public PartialViewResult MenuAlive(string category, string status)
        {
            return PartialView("MenuAlive", category);
        }

    }
}