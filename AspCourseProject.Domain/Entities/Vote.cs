﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCourseProject.Domain.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }
        public string UserName { get; set; }
        public int Week { get; set; }
    }
}
