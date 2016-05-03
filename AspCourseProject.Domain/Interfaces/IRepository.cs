using System.Linq;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain.Interfaces
{
    public interface IRepository
    {
        IQueryable<Person> Table { get; }
        void SavePerson(Person person);
        void RemovePerson(int id);

        IQueryable<VoteItem> VoteItems { get; }
        void SaveVoteItem(VoteItem voteItem);

        IQueryable<Vote> Votes { get; }
        void SaveVote(Vote vote);

        IQueryable<Comment> Comments { get; }
        void SaveComment(Comment comment);
    }
}