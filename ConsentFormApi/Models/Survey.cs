using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Survey
    {
        public Survey()
        {
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        public ICollection<Topic> Topics { get; set; }
    }
}
