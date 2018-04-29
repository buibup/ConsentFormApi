using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;
using ConsentFormApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsentFormApi.Controllers
{
    [Produces("application/json")]
    //[Route("api/CustomerSurvey")]
    public class CustomerSurveyController : Controller
    {
        private readonly ICustomerSurveyService _customerSurveyService;
        public CustomerSurveyController(ICustomerSurveyService customerSurveyService)
        {
            _customerSurveyService = customerSurveyService;
        }

        [HttpGet("api/[controller]/[action]/{customerId}")]
        public IActionResult GetCustomerSurveys(long customerId)
        {
            return Ok(_customerSurveyService.GetCustomerSurveyDatas(customerId));
        }
    }
}