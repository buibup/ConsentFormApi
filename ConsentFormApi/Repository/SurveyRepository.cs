
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Common;
using ConsentFormApi.DbQuery;
using ConsentFormApi.Models;
using Dapper;

namespace ConsentFormApi.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public SurveyRepository(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public long AddSurvey(Survey survey)
        {
            using(var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                return db.Query<long>(SurveyDbQuery.AddSurvey(), new { Name = survey.Name }).SingleOrDefault();
            }
        }

        public void DeleteSurvey(long id)
        {
            using (var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                db.Query(SurveyDbQuery.DeleteSurvey(), new { Id = id });
            }
        }

        public Survey GetSurvey(long id)
        {
            using(var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                return db.Query<Survey>(SurveyDbQuery.GetSurvey(), new { Id = id }).FirstOrDefault();
            }
        }

        public List<Survey> GetSurveys()
        {
            using (var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                return db.Query<Survey>(SurveyDbQuery.GetSurveys()).ToList();
            }
        }

        public bool SurveyExists(long id)
        {
            using(var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                return db.ExecuteScalar<bool>(SurveyDbQuery.SurveyExits(), new { id });
            }
        }

        public void UpdateSurvey(Survey survey)
        {
            using(var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                db.Execute(SurveyDbQuery.UpdateSuervey(), new { survey.Name });
            }
        }
    }
}
