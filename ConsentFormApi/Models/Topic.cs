﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsentFormApi.Models
{
    public class Topic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SurveyId { get; set; }
    }
}