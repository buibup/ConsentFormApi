using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class TemplateDetails
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
