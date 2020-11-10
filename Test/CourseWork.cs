using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class CourseWork
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseWork()
        {
            Title = "";
            Description = "";
        }
        public CourseWork(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public override string ToString()
        {
            return Title + "$" + Description;
        }
    }
}
