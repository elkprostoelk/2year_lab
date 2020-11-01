using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class CourseWork
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public CourseWork()
        {
            Topic = "";
            Description = "";
        }
        public CourseWork(string topic, string description)
        {
            Topic = topic;
            Description = description;
        }
    }
}
