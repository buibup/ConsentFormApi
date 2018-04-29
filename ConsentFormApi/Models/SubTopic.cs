﻿using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class SubTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
