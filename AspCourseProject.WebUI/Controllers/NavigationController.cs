﻿using System.Linq;
using System.Web.Mvc;
using AspCourseProject.Domain.Interfaces;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class NavigationController: Controller
    {
        private IRepository repository;
        public NavigationController(IRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult MenuCategory(string category ="all", string status="all")
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
        public PartialViewResult MenuAlive(string category="all", string status="all")
        {
            return PartialView("MenuAlive", category);
        }

        public PartialViewResult Search(string category, string status)
        {
            var model = new UrlViewModel
            {
                CurrentCategory = category,
                CurrentStatus = status
            };
            return PartialView("Search", model);
        }

    }
}