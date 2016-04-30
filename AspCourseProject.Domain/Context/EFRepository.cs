using System.Linq;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;

namespace AspCourseProject.Domain.Context
{
    public class EFRepository : IPersonRepository, IVoteRepository, IVoteItemsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Person> Table => context.Table;
        public IQueryable<VoteItems> VoteItems => context.VoteItems;
        public IQueryable<Vote> Votes => context.Votes;
    }
}