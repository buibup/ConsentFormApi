using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class CustomersAgrees
    {
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
        public DateTime SignedAt { get; set; }
        public int Id { get; set; }
        public string Paper { get; set; }

        public Customers Customer { get; set; }
        public Templates Template { get; set; }
    }
}
