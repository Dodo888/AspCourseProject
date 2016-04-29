using System.Data.Entity;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain
{
    public class EFDbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}