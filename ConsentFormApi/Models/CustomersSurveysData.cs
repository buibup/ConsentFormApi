using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class CustomersSurveysData
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SurveyId { get; set; }
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
