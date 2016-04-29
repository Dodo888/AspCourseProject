using System.Linq;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain
{
    public class EFPersonRepository : IPersonRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Person> Table => context.Table;
    }
}