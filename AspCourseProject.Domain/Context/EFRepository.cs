using System.Linq;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;

namespace AspCourseProject.Domain.Context
{
    public class EFRepository : IRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Person> Table => context.Table;
        public void SavePerson(Person person)
        {
            if (person.PersonId == 0)
            {
                context.Table.Add(person);
            }
            else
            {
                Person dbEntry = context.Table.Find(person.PersonId);
                if (dbEntry != null)
                {
                    dbEntry.Name = person.Name;
                    dbEntry.Description = person.Description;
                    dbEntry.Price = person.Price;
                    dbEntry.Category = person.Category;
                    dbEntry.Gender = person.Gender;
                    dbEntry.IsAlive = person.IsAlive;
                    dbEntry.Rating = person.Rating;
                    dbEntry.ImageData = person.ImageData;
                    dbEntry.ImageMimeType = person.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public void RemovePerson(int id)
        {
            var person = context.Table.Find(id);
            context.Table.Remove(person);
            context.SaveChanges();
        }

        public IQueryable<Comment> Comments => context.Comments;
        public void SaveComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

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