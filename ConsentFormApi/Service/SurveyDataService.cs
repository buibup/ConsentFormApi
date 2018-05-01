using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;
using ConsentFormApi.Repository;

namespace ConsentFormApi.Service
{
    public class SurveyDataService : ISurveyDataService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly ICustomerSurveyRepository _customerSurveyRepository;

        public SurveyDataService(ISurveyRepository surveyRepository, ICustomerSurveyRepository customerSurveyRepository)
        {
            _surveyRepository = surveyRepository;
            _customerSurveyRepository = customerSurveyRepository;
        }
        public List<SubTopicValue> SubTopicValuesByYear(int year)
        {
            var customerSurveyDatas = _customerSurveyRepository.CustomerSurveyData(year);


            throw new NotImplementedException();
        }
    }
}
