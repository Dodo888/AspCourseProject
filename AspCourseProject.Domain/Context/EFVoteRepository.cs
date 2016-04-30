using System.Linq;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain.Context
{
    public class EFVoteRepository : IVoteRepository
    {

        private EFDbContext context = new EFDbContext();
        public IQueryable<Vote> Votes => context.Votes;
    }
}
