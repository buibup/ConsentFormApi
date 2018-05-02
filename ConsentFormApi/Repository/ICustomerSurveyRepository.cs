using ConsentFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Repository
{
    public interface ICustomerSurveyRepository
    {
        IEnumerable<CustomerSurveyData> GetCustomerSurveyDatas(long customerId);
        IEnumerable<CustomerSurveyData> GetCustomerSurveyData(int surveyId, int year);
        IEnumerable<CustomerSurveyData> GetCustomerSurveyData(int surveyId, int year, int month);
    }
}
