using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Teacher : Person
    {
        public float Salary { get; set; }
        public int MaxNumberOfCourseWorks { get; private set; }
        public List<Student> CourseWorkStudents { get; private set; }
        private AcademicDegrees academicdegree;
        public string AcademicDegree
        {
            get
            {
                switch (academicdegree)
                {
                    case AcademicDegrees.DoctorOfSсiences:
                        { return "Doctor of Sciences"; }
                    case AcademicDegrees.CandidateOfSciences:
                        { return "Candidate of Sciences"; }
                    case AcademicDegrees.Masters:
                        { return "Masters"; }
                    case AcademicDegrees.Bachelors:
                        { return "Bachelors"; }
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (value)
                {
                    case "Doctor of Sciences":
                        { this.academicdegree = AcademicDegrees.DoctorOfSсiences; break; }
                    case "Candidate of Sciences":
                        { this.academicdegree = AcademicDegrees.CandidateOfSciences; break; }
                    case "Masters":
                        { this.academicdegree = AcademicDegrees.Masters; break; }
                    case "Bachelors":
                        { this.academicdegree = AcademicDegrees.Bachelors; break; }
                    default:
                        { this.academicdegree = AcademicDegrees.Bachelors; break; }
                }
            }
        }
        private Ranks title;
        public string Title
        {
            get
            {
                switch (this.title)
                {
                    case Ranks.Professor:
                        return "Professor";
                    case Ranks.Docent:
                        return "Docent";
                    case Ranks.ElderTeacher:
                        return "Elder Teacher";
                    case Ranks.Teacher:
                        return "Teacher";
                    case Ranks.Assistant:
                        return "Assistant";
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (Title)
                {
                    case "Professor":
                        { this.title = Ranks.Professor; break; }
                    case "Docent":
                        { this.title = Ranks.Docent; break; }
                    case "Elder Teacher":
                        { this.title = Ranks.ElderTeacher; break; }
                    case "Teacher":
                        { this.title = Ranks.Teacher; break; }
                    case "Assistant":
                        { this.title = Ranks.Assistant; break; }
                    default:
                        { this.title = Ranks.Assistant; break; }
                }
            }
        }
        public enum AcademicDegrees
        {
            DoctorOfSсiences = 1,
            CandidateOfSciences,
            Masters,
            Bachelors
        }
        public enum Ranks
        {
            Professor = 1,
            Docent,
            ElderTeacher,
            Teacher,
            Assistant
        }
        public Teacher() : base()
        {
            Salary = 0f;
            academicdegree = AcademicDegrees.Masters;
            title = Ranks.Teacher;
            MaxNumberOfCourseWorks = 1;
            CourseWorkStudents = new List<Student>(MaxNumberOfCourseWorks);
        }
        public Teacher(string name, int age, AddressField address, float salary, int maxnumofcourseworks, string acaddegree, string title) : base(name, age, address)
        {
            Salary = salary;
            AcademicDegree = acaddegree;
            Title = title;
            MaxNumberOfCourseWorks = maxnumofcourseworks;
            CourseWorkStudents = new List<Student>(MaxNumberOfCourseWorks);
        }
        public void AddCourseWorkStudent(Student student)
        {
            CourseWorkStudents.Add(student);
        }
        public void DeleteCourseWorkStudent(Student student)
        {
            CourseWorkStudents.Remove(student);
            student.courseWork = null;
        }
        public override string ToString()
        {
            string result = base.ToString() + "|";
            result += this.Salary + "|";
            result += this.AcademicDegree + "|";
            result += this.Title + "|";
            foreach (var item in CourseWorkStudents)
                result += item.Name + "|" + item.courseWork.Title;
            return result;
        }
    }
}
