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
        private Ranks Title;
        public float getSalary() { return this.Salary; }
        public void setSalary(float Salary) { this.Salary = Salary; }
        public int getMaxNumberOfCourseWorks() { return this.MaxNumberOfCourseWorks; }
        public void setMaxNumberOfCourseWorks(int maxNum) { this.MaxNumberOfCourseWorks = maxNum; }
        public List<Student> getCourseWorkStudents() { return this.CourseWorkStudents; }
        public void setCourseWorkStudents(List<Student> students) { this.CourseWorkStudents = students; }
        public void setAcademicDegree(string acaddegree)
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
        public string getAcademicDegree()
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
        public string getTitle()
        {
            switch (this.Title)
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
        public void setTitle(string title)
        {
            switch (title)
            {
                case "Professor":
                    { this.Title = Ranks.Professor; break; }
                case "Docent":
                    { this.Title = Ranks.Docent; break; }
                case "Elder Teacher":
                    { this.Title = Ranks.ElderTeacher; break; }
                case "Teacher":
                    { this.Title = Ranks.Teacher; break; }
                case "Assistant":
                    { this.Title = Ranks.Assistant; break; }
                default:
                    { this.Title = Ranks.Assistant; break; }
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
            AcademicDegree = AcademicDegrees.Masters;
            Title = Ranks.Teacher;
            MaxNumberOfCourseWorks = 1;
            CourseWorkStudents = new List<Student>(MaxNumberOfCourseWorks);
        }
        public Teacher(string name, int age, AddressField address, float salary, int maxnumofcourseworks, string acaddegree, string title) : base(name, age, address)
        {
            Salary = salary;
            this.setAcademicDegree(acaddegree);
            this.setTitle(title);
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
            string result = base.ToString() + "|";
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
