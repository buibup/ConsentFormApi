using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.DbQuery
{
    public static class SurveyDbQuery
    {
        public static string GetSurvey()
        {
            return @"
                SELECT id Id, name Name
                FROM consentDb.dbo.surveys
                WHERE id = @Id;";
        }

        public static string GetSurveys()
        {
            return @"SELECT id Id, name Name
                FROM consentDb.dbo.surveys;";
        }

        public static string AddSurvey()
        {
            return @"INSERT INTO consentDb.dbo.surveys
                (name) VALUES(@Name)
                SELECT CAST(SCOPE_IDENTITY() as int);
                ";
        }

        public static string UpdateSuervey()
        {
            return @"UPDATE consentDb.dbo.surveys
                SET name=@Name
                WHERE id = @Id;
                ";
        }

        public static string DeleteSurvey()
        {
            return @"DELETE FROM consentDb.dbo.surveys
                WHERE id = @Id;
                ";
        }

        public static string SurveyExits()
        {
            return "SELECT COUNT(1) FROM consentDb.dbo.surveys WHERE id=@Id";
        }
        
        public static string GetTopic()
        {
            return @"SELECT id Id, name Name, survey_id SurveyId
                FROM consentDb.dbo.topics
                WHERE survey_id = @SurveyId ";
        }

        public static string GetSubTopic()
        {
            return @"SELECT id Id, name Name, topic_Id TopicId
                FROM consentDb.dbo.sub_topics
                WHERE topic_Id IN @TopicId";
        }

        public static string GetSurveyChild()
        {
            return @"
                SELECT s.id Id, s.name Name,
                t.id Id, t.name Name, t.survey_id SurveyId,
                st.id Id, st.name Name, st.topic_Id TopicId
                FROM consentDb.dbo.surveys s
                INNER JOIN consentDb.dbo.topics t ON s.id = t.survey_id
                INNER JOIN consentDb.dbo.sub_topics st ON t.id = st.topic_Id
                WHERE s.id = @Id
            ";
        }
    }
}
