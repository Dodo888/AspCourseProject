using System.Linq;
using System.Web.Mvc;
using AspCourseProject.Domain;
using AspCourseProject.WebUI.Models;

namespace AspCourseProject.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository repository;
        public int pageSize = 2;
        public PersonController(IPersonRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, string status, string subName = (string)null, int page = 1)
        {
            var filterResult = repository.Table
                .Where(p => category == "all" || p.Category == category)
                .Where(p => status == "all" || p.IsAlive == (status == "alive"))
                .Where(p => subName == (string)null || p.Name.Contains(subName));
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
                CurrentStatus = status
            };
            return View(model);
        }
    }
}