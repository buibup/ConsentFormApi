
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
                var survey = db.Query<Survey>(SurveyDbQuery.GetSurvey(), new { Id = id }).FirstOrDefault();

                var topics = db.Query<Topic>(SurveyDbQuery.GetTopic(), new { SurveyId = id }).ToList();

                var topicIdList = topics.Select(t => t.Id).Distinct();

                var subTopics = db.Query<SubTopic>(SurveyDbQuery.GetSubTopic(), new { @TopicId = topicIdList });

                foreach(var topic in topics)
                {
                    foreach (var subTopic in subTopics)
                    {
                        if(topic.Id == subTopic.TopicId)
                        {
                            topic.SubTopics.Add(subTopic);
                        }
                    }
                }

                survey.Topics = topics;

                return survey;
            }
        }

        public Survey GetSurveyChild(long id)
        {
            using(var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                var surveyDictionary = new Dictionary<int, Survey>();

                var result = db.Query<Survey, Topic, SubTopic, Survey>(SurveyDbQuery.GetSurveyChild(),
                    (survey, topic, subTopic) =>
                    {

                        //topic.SubTopics.Add(subTopic);
                        //survey.Topics.Add(topic);


                        //return survey;

                        if (!surveyDictionary.TryGetValue(survey.Id, out Survey surveyEntry))
                        {
                            surveyEntry = survey;
                            surveyEntry.Topics = new List<Topic>();
                            surveyDictionary.Add(surveyEntry.Id, surveyEntry);
                        }

                        if (survey.Id == topic.SurveyId)
                        {
                            surveyEntry.Topics.Add(topic);
                        }

                        return surveyEntry;

                    }, new { id }, splitOn: "id").FirstOrDefault();

                return result;
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
