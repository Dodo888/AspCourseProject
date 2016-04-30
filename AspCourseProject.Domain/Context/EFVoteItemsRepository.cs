using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;

namespace AspCourseProject.Domain.Context
{
    public class EFVoteItemsRepository : IVoteItemsRepository
    {

            private EFDbContext context = new EFDbContext();
            public IQueryable<VoteItems> VoteItems => context.VoteItems;
        
    }
}
