using System.Collections.Generic;
using System.Linq;

namespace AspCourseProject.Domain.Entities
{
    public class VoteResults
    {
        private List<Person> Votes = new List<Person>();

        public void AddVote(Person person)
        {
            Person vote = Votes.FirstOrDefault(p => p.PersonId == person.PersonId);
            if (vote == null)
            {
                Votes.Add(person);
            }
        }

        public void RemoveVote(Person person)
        {
            Votes.RemoveAll(l => l.PersonId == person.PersonId);
        }

        public int GetVotesPrice()
        {
            return Votes.Sum(e => e.Price);
        }

        public void Clear()
        {
            Votes.Clear();
        }

        public IEnumerable<Person> GetVotes => Votes;
    }
}
