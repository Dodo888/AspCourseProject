using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain.Interfaces
{
    public interface IVoteItemsRepository
    {
        IQueryable<VoteItem> VoteItems { get; }
        void SaveVoteItem(VoteItem voteItem);
    }
}
