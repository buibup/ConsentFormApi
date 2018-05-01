using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Topic
    {
        public Topic()
        {
            SubTopics = new HashSet<SubTopic>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }

        [JsonIgnore]
        public Survey Survey { get; set; }
        public ICollection<SubTopic> SubTopics { get; set; }
    }
}
