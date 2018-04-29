using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsentFormApi.Models;

namespace ConsentFormApi.Service
{
    public class SurveyChartsService : ISurveyChartsService
    {
        private readonly SurveyBarChart surveyBarChart = new SurveyBarChart();

        public SurveyBarChart GetSurveyBarChart(int year)
        {
            return surveyBarChart.GetDataExample();
        }
    }
}
