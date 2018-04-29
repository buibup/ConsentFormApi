using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Attachments
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ExpiryAt { get; set; }
        public string FileName { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
