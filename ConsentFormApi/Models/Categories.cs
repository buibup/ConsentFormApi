using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Templates = new HashSet<Templates>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Templates> Templates { get; set; }
    }
}
