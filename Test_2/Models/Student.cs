using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Student : Person
    {
        private string Faculty;
        private string Group;
        private bool isState;
        private float Scholarship;
        private float AverageBall;
        private CourseWork courseWork;
        public Student() : base()
        {
            Faculty = "FCSPM";
            Group = "241";
            isState = false;
            Scholarship = 0f;
            AverageBall = 0f;
            courseWork = null;
        }
        public Student(string name, int age, AddressField address, string faculty, string group, string isstate, float scholarship, float averball, CourseWork courseWork) : base(name, age, address)
        {
            Faculty = faculty;
            Group = group;
            if (isstate.ToLower() == "бюджетная") isState = true;
            else isState = false;
            Scholarship = scholarship;
            AverageBall = averball;
            this.courseWork = courseWork;
        }
        public string getFaculty() { return this.Faculty; }
        public void setFaculty(string Faculty) { this.Faculty = Faculty; }
        public string getGroup() { return this.Group; }
        public void setGroup(string Group) { this.Group = Group; }
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
            string result = this.GetType().Name + "|" + base.ToString();
            result += "|" + this.Faculty + "|";
            result += this.Group + "|";
            if (this.isState) result += "Бюджетная|";
            else result += "Контрактная|";
            result += this.Scholarship + "|";
            result += this.AverageBall + "|";
            result += this.courseWork.ToString();
            return result;
        }
        public override string GetTypeName()
        {
            return this.GetType().Name;
        }
    }
}
