using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using AspCourseProject.Domain.Interfaces;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IRepository repository;
        public int pageSize = 2;
        public PersonController(IRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category="all", string status="all", string subName = (string)null, int page = 1)
        {
            var filterResult = repository.Table
                .Where(p => category == "all" || p.Category == category)
                .Where(p => status == "all" || p.IsAlive == (status == "alive"))
                .Where(p => subName == (string)null || p.Name.Contains(subName));
            var currentWeek = 1;
            var isVoted = repository.Votes.Any(x => x.Week == currentWeek && x.UserName == User.Identity.Name);
            PersonsListViewModel model = new PersonsListViewModel
            {
                Persons = filterResult.OrderBy(p => p.PersonId)
                    .Skip((page - 1)*pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = filterResult.Count()
                },
                CurrentCategory = category,
                CurrentStatus = status,
                IsVoted = isVoted
            };
            return View(model);
        }
    }
}