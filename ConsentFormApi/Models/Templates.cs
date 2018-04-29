using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Templates
    {
        public Templates()
        {
            CustomersAgrees = new HashSet<CustomersAgrees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Categories Category { get; set; }
        public ICollection<CustomersAgrees> CustomersAgrees { get; set; }
    }
}
