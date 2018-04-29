using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class ApplicationConfigurations
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public byte[] CreatedAt { get; set; }
    }
}
