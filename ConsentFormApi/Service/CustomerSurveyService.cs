using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;
using ConsentFormApi.Repository;

namespace ConsentFormApi.Service
{
    public class CustomerSurveyService : ICustomerSurveyService
    {
        private readonly ICustomerSurveyRepository _customerSurveyRepository;
        public CustomerSurveyService(ICustomerSurveyRepository customerSurveyRepository)
        {
            _customerSurveyRepository = customerSurveyRepository;
        }

        public IEnumerable<CustomerSurveyData> GetCustomerSurveyDatas(long customerId)
        {
            return _customerSurveyRepository.GetCustomerSurveyDatas(customerId);
        }
    }
}
