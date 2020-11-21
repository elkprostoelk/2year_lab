using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Student : Person
    {
        private bool isState;
        private float Scholarship;
        private float AverageBall;
        private CourseWork courseWork;
        public Student() : base()
        {
            isState = false;
            Scholarship = 0f;
            AverageBall = 0f;
            courseWork = new CourseWork();
        }
        public Student(string name, int age, AddressField address, string isstate, float scholarship, float averball, CourseWork courseWork) : base(name, age, address)
        {
            if (isstate.ToLower() == "state") isState = true;
            else isState = false;
            Scholarship = scholarship;
            AverageBall = averball;
            this.courseWork = courseWork;
        }
        public bool getIsState() { return this.isState; }
        public void setIsState(bool isState) { this.isState = isState; }
        public float getScholarship() { return this.Scholarship; }
        public void setScholarship(float Scholarship) { this.Scholarship = Scholarship; }
        public float getAverageBall() { return this.AverageBall; }
        public void setAverageBall(float AverageBall) { this.AverageBall = AverageBall; }
        public CourseWork getCourseWork() { return this.courseWork; }
        public void setCourseWork(CourseWork courseWork) { this.courseWork = courseWork; }
        public override string ToString()
        {
            string result = base.ToString();
            if (isState) result += "|State|";
            else result += "|Contract|";
            result += Scholarship + "|";
            result += AverageBall + "|";
            result += courseWork.ToString();
            return result;
        }
    }
}
