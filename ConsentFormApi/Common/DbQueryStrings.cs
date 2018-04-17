using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Common
{
    public static class DbQueryStrings
    {
        public static string GetCustomerSurvey()
        {
            const string query = @"
                select csd.id Id, csd.customer_id CustomerId, csd.survey_id SurveyId, 
                    csd.topic_id TopicId, csd.sub_topic_id SubTopicId,
                    csd.value Value,csd.created_at CreatedAt,
                    s.name SurveyName, t.name TopicName, st.name SubTopicName
                from [dbo].[customers_surveys_data] csd
                    join surveys s on csd.survey_id = s.id
                    join topics t on csd.topic_id = t.id
                    join sub_topics st on csd.sub_topic_id = st.id
                where customer_id = @customer_id
            ";

            return query;
        }
    }
}
