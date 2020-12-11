using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Teacher : Person
    {
        private float Salary;
        private int MaxNumberOfCourseWorks;
        private List<Student> CourseWorkStudents;
        private AcademicDegrees AcademicDegree;
        private Titles Title;
        public float getSalary() { return this.Salary; }
        public void setSalary(float Salary) { this.Salary = Salary; }
        public int getMaxNumberOfCourseWorks() { return this.MaxNumberOfCourseWorks; }
        public void setMaxNumberOfCourseWorks(int maxNum) { this.MaxNumberOfCourseWorks = maxNum; }
        public List<Student> getCourseWorkStudents() { return this.CourseWorkStudents; }
        public void setCourseWorkStudents(List<Student> students) { this.CourseWorkStudents = students; }
        public AcademicDegrees getAcademicDegree() { return this.AcademicDegree; }
        public void setAcademicDegree(AcademicDegrees academicDegree) { this.AcademicDegree = academicDegree; }
        public Titles getTitle() { return this.Title; }
        public void setTitle(Titles title) { this.Title = title; }
        public void setAcademicDegreeStr(string acaddegree)
        {
            switch (acaddegree)
            {
                case "Doctor of Sciences":
                    { this.AcademicDegree = AcademicDegrees.DoctorOfSсiences; break; }
                case "Candidate of Sciences":
                    { this.AcademicDegree = AcademicDegrees.CandidateOfSciences; break; }
                case "Masters":
                    { this.AcademicDegree = AcademicDegrees.Masters; break; }
                case "Bachelors":
                    { this.AcademicDegree = AcademicDegrees.Bachelors; break; }
                default:
                    { this.AcademicDegree = AcademicDegrees.Bachelors; break; }
            }
        }
        public string getAcademicDegreeStr()
        {
            switch (AcademicDegree)
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
        public string getTitleStr()
        {
            switch (this.Title)
            {
                case Titles.Professor:
                    return "Professor";
                case Titles.Docent:
                    return "Docent";
                case Titles.ElderTeacher:
                    return "Elder Teacher";
                case Titles.Teacher:
                    return "Teacher";
                case Titles.Assistant:
                    return "Assistant";
                default:
                    return string.Empty;
            }
        }
        public void setTitleStr(string title)
        {
            switch (title)
            {
                case "Professor":
                    { this.Title = Titles.Professor; break; }
                case "Docent":
                    { this.Title = Titles.Docent; break; }
                case "Elder Teacher":
                    { this.Title = Titles.ElderTeacher; break; }
                case "Teacher":
                    { this.Title = Titles.Teacher; break; }
                case "Assistant":
                    { this.Title = Titles.Assistant; break; }
                default:
                    { this.Title = Titles.Assistant; break; }
            }
        }
        public enum AcademicDegrees
        {
            DoctorOfSсiences,
            CandidateOfSciences,
            Masters,
            Bachelors
        }
        public enum Titles
        {
            Professor,
            Docent,
            ElderTeacher,
            Teacher,
            Assistant
        }
        public Teacher() : base()
        {
            Salary = 0f;
            AcademicDegree = AcademicDegrees.Masters;
            Title = Titles.Teacher;
            MaxNumberOfCourseWorks = 1;
            CourseWorkStudents = new List<Student>(MaxNumberOfCourseWorks);
        }
        public Teacher(string name, int age, AddressField address, float salary, int maxnumofcourseworks, string acaddegree, string title) : base(name, age, address)
        {
            Salary = salary;
            this.setAcademicDegreeStr(acaddegree);
            this.setTitleStr(title);
            MaxNumberOfCourseWorks = maxnumofcourseworks;
            CourseWorkStudents = new List<Student>(MaxNumberOfCourseWorks);
        }
        public void AddCourseWorkStudent(Student student)
        {
            if (CourseWorkStudents.Count == MaxNumberOfCourseWorks) throw new IndexOutOfRangeException("Максимальное количество студентов записано!");
            else CourseWorkStudents.Add(student);
        }
        public void DeleteCourseWorkStudent(Student student)
        {
            CourseWorkStudents.Remove(student);
            student.setCourseWork(null);
        }
        public override string ToString()
        {
            string result = this.GetType().Name + "|" + base.ToString() + "|";
            result += this.Salary + "|";
            result += this.MaxNumberOfCourseWorks + "|";
            result += this.AcademicDegree + "|";
            result += this.Title + "|";
            foreach (var item in CourseWorkStudents)
                result += item.getName() + "&";
            return result.Remove(result.LastIndexOf('&'));
        }
    }
}
