using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;
using ConsentFormApi.Repository;
using ConsentFormApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsentFormApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Survey")]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly ISurveyChartsService _surveyChartsService;

        public SurveyController(ISurveyRepository surveyRepository, ISurveyChartsService surveyChartsService)
        {
            _surveyRepository = surveyRepository;
            _surveyChartsService = surveyChartsService;
        }

        [HttpGet("[action]")]
        public IActionResult GetSurveys()
        {
            return Ok(_surveyRepository.GetSurveys());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetSurvey(long id)
        {
            return Ok(_surveyRepository.GetSurveyChild(id));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteSurvey(long id)
        {
            if (!_surveyRepository.SurveyExists(id))
            {
                return NotFound();
            }

            _surveyRepository.DeleteSurvey(id);

            return NoContent();
        }

        [HttpPost("[action]")]
        public IActionResult AddSurvey([FromBody]Survey survey)
        {
            if(survey == null)
            {
                return BadRequest();
            }

            var surveyId = _surveyRepository.AddSurvey(survey);
            var result = _surveyRepository.GetSurvey(surveyId);


            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult UpdateSurvey(long id, [FromBody]Survey survey)
        {
            if(survey == null || id != survey.Id)
            {
                return BadRequest();
            }

            _surveyRepository.UpdateSurvey(survey);

            return NoContent();
        }

        [HttpGet("[action]/{year}")]
        public IActionResult GetSurveyChart(int year)
        {
            return Ok(_surveyChartsService.GetSurveyBarChart(year));
        }
    }
}