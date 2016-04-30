using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain
{
    public interface IVoteRepository
    {
        IQueryable<Vote> Votes { get; }
        void SaveVote(Vote vote);
    }
}
