using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.DbQuery
{
    public static
        class CustomerSurveyDbQuery
    {
        public static string CustomersSurveysDataByYear()
        {
            return @"SELECT id Id, customer_id CustomerId, survey_id SurveyId, topic_id TopicId, 
                sub_topic_id SubTopicId, value Value, created_at CreatedAt
                FROM consentDb.dbo.customers_surveys_data
                WHERE YEAR(created_at) = @Year
                ";
        }
    }
}
