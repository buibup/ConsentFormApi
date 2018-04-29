using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string SsusrInitials { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte? Active { get; set; }
    }
}
