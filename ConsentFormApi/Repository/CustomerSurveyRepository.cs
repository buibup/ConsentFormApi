using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Common;
using ConsentFormApi.Models;
using Dapper;

namespace ConsentFormApi.Repository
{
    public class CustomerSurveyRepository : ICustomerSurveyRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public CustomerSurveyRepository(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }
        public IEnumerable<CustomerSurveyData> GetCustomerSurveyDatas(long customerId)
        {
            using (var db = new SqlConnection(_connectionStrings.ConsentForm))
            {
                return db.Query<CustomerSurveyData>(DbQueryStrings.GetCustomerSurvey(), new { customer_id = customerId }).ToList();
            }
        }
    }
}
