using System.Linq;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain
{
    public interface IPersonRepository
    {
        IQueryable<Person> Table { get; }
    }
}