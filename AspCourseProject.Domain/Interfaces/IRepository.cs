using System.Linq;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain.Interfaces
{
    public interface IRepository
    {
        IQueryable<Person> Table { get; }

        IQueryable<VoteItem> VoteItems { get; }
        void SaveVoteItem(VoteItem voteItem);

        IQueryable<Vote> Votes { get; }
        void SaveVote(Vote vote);
    }
}