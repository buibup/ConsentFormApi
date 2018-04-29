using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Models
{
    public class SurveyBarChart
    {
        public List<SubTopicValue> SubTopicValues { get; set; }
        public string[] ChartLabels { get; set; }

        public SurveyBarChart()
        {
            SubTopicValues = new List<SubTopicValue>();
        }

        public SurveyBarChart GetDataExample()
        {
            var subTopicsValue = new List<SubTopicValue>()
            {
                new SubTopicValue { SubTopicName = "The staff is courteous.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "I receive clear information from the staff.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "The staff is knowledgeable.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "Appointments are available in a reasonable time frame.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "Appointment times are convenient.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "The physicians meet my needs.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "Payment options meet my needs.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
                new SubTopicValue { SubTopicName = "Patients are the top priority at BWC Hospital.", Values = new double[] { 5, 4.5, 5, 5, 4, 4.9, 5, 4.5, 5, 5, 4, 4.9 } },
            };

            List<string> barChartLabelList = new List<string>();

            for (int i = 1; i <= 12; i++)
            {
                barChartLabelList.AddRange(new string[] { $"{(MonthOfYear)i}" });
            }

            return new SurveyBarChart { SubTopicValues = subTopicsValue, ChartLabels = barChartLabelList.ToArray() } ;
        }
    }

    public class SubTopicValue
    {
        public double[] Values { get; set; }
        public string SubTopicName  { get; set; }
    }
}
