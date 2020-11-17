using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class CourseWork
    {
        private string Title { get; set; }
        private string Description { get; set; }
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
        public string getTitle() { return this.Title; }
        public void setTitle(string Title) { this.Title = Title; }
        public string getDescription() { return this.Description; }
        public void setDescription(string Description) { this.Description = Description; }
        public override string ToString()
        {
            return Title + "$" + Description;
        }
    }
}
