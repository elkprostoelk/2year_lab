using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Student : Person
    {
        public bool isState { get; set; }
        public float Scholarship { get; set; }
        public float AverageBall { get; set; }
        public CourseWork courseWork { get; set; }
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
        public static bool operator ==(Student a, Student b)
        {
            return (Person)a == (Person)b && a.isState == b.isState && a.Scholarship == b.Scholarship && a.AverageBall == b.AverageBall && a.courseWork == b.courseWork;
        }
        public static bool operator !=(Student a, Student b)
        {
            return (Person)a != (Person)b || a.isState != b.isState || a.Scholarship != b.Scholarship || a.AverageBall != b.AverageBall || a.courseWork != b.courseWork;
        }
    }
}
