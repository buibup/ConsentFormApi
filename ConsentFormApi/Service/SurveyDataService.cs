using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;
using ConsentFormApi.Repository;
using static System.Enum;

namespace ConsentFormApi.Service
{
    public class SurveyDataService : ISurveyDataService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly ICustomerSurveyRepository _customerSurveyRepository;

        public SurveyDataService(ISurveyRepository surveyRepository,
            ICustomerSurveyRepository customerSurveyRepository)
        {
            _surveyRepository = surveyRepository;
            _customerSurveyRepository = customerSurveyRepository;
        }

        public List<SubTopicValue> GetSubTopicValuesByMonth(int surveyId, int year, int month)
        {
            var customerSurveyDatas = _customerSurveyRepository.GetCustomerSurveyData(surveyId, year, month);
            var subTopicIdList = customerSurveyDatas.Select(subTop => subTop.Id).Distinct();

            var topics = _surveyRepository.GetSurvey(surveyId).Topics;
            var subTopics = topics.Select(t => t.SubTopics).FirstOrDefault();

            var result = new List<SubTopicValue>();

            foreach (var subTopId in subTopicIdList)
            {
                var subTopicValue = new SubTopicValue();
                double sumValue = 0;
                int countValue = 0;

                foreach (var item in customerSurveyDatas)
                {
                    if (subTopId == item.SubTopicId)
                    {
                        countValue += 1;
                        sumValue += item.value;
                    }
                }

                double avgValue = sumValue / countValue;

                subTopicValue.Values[0] = avgValue;
                subTopicValue.SubTopicName = subTopics.FirstOrDefault(item => item.Id == subTopId).Name;

                result.Add(subTopicValue);
            }

            return result;
        }

        public List<SubTopicValue> GetSubTopicValuesByYear(int surveyId, int year)
        {
            var customerSurveyDatas = _customerSurveyRepository.GetCustomerSurveyData(surveyId, year);

            foreach (MonthOfYear month in GetValues(typeof(MonthOfYear)))
            {
                foreach (var item in customerSurveyDatas)
                {

                }
            }

            return null;
        }
    }
}
