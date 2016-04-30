using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCourseProject.Domain.Entities
{
    public class VoteItem
    {
        public int VoteItemsId { get; set; }
        public int UserId { get; set; }
        public int PersonId { get; set; }
    }
}
