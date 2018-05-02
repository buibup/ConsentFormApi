using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Models
{
    public class CustomerSurveyData
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long SurveyId { get; set; }
        public long TopicId { get; set; }
        public long SubTopicId { get; set; }
        public double value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
