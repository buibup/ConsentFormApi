﻿using ConsentFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Service
{
    public interface ISurveyDataService
    {
        List<SubTopicValue> GetSubTopicValuesByYear(int surveyId, int year);
        List<SubTopicValue> GetSubTopicValuesByMonth(int surveyId, int year, int month);
    }
}
