using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Models
{
    public class SubTopic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SubTopicId { get; set; }
    }
}
