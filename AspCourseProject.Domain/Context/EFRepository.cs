using System.Linq;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;

namespace AspCourseProject.Domain.Context
{
    public class EFRepository : IPersonRepository, IVoteRepository, IVoteItemsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Person> Table => context.Table;

        public IQueryable<VoteItem> VoteItems => context.VoteItems;
        public void SaveVoteItem(VoteItem voteItem)
        {
            context.VoteItems.Add(voteItem);
            context.SaveChanges();
        }

        public IQueryable<Vote> Votes => context.Votes;
        public void SaveVote(Vote vote)
        {
            context.Votes.Add(vote);
            context.SaveChanges();
        }
    }
}