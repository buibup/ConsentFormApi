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
                WHERE id=@Id;
                ";
        }

        public static string DeleteSurvey()
        {
            return @"DELETE FROM consentDb.dbo.surveys
                WHERE id=@Id;
                ";
        }

        public static string SurveyExits()
        {
            return "SELECT COUNT(1) FROM consentDb.dbo.surveys WHERE id=@Id";
        }
    }
}
