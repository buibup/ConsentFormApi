using ConsentFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Repository
{
    public interface ISurveyRepository
    {
        Survey GetSurvey(long id);
        Survey GetSurveyChild(long id);
        List<Survey> GetSurveys();
        long AddSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(long id);
        bool SurveyExists(long id);
    }
}
