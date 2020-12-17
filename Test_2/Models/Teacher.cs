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
                case "Доктор наук":
                    { this.AcademicDegree = AcademicDegrees.DoctorOfSсiences; break; }
                case "Кандидат наук":
                    { this.AcademicDegree = AcademicDegrees.CandidateOfSciences; break; }
                case "Магистр":
                    { this.AcademicDegree = AcademicDegrees.Masters; break; }
                case "Бакалавр":
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
                    { return "Доктор наук"; }
                case AcademicDegrees.CandidateOfSciences:
                    { return "Кандидат наук"; }
                case AcademicDegrees.Masters:
                    { return "Магистр"; }
                case AcademicDegrees.Bachelors:
                    { return "Бакалавр"; }
                default:
                    return string.Empty;
            }
        }
        public string getTitleStr()
        {
            switch (this.Title)
            {
                case Titles.Professor:
                    return "Профессор";
                case Titles.Docent:
                    return "Доцент";
                case Titles.ElderTeacher:
                    return "Старший преподаватель";
                case Titles.Teacher:
                    return "Преподаватель";
                case Titles.Assistant:
                    return "Ассистент";
                default:
                    return string.Empty;
            }
        }
        public void setTitleStr(string title)
        {
            switch (title)
            {
                case "Профессор":
                    { this.Title = Titles.Professor; break; }
                case "Доцент":
                    { this.Title = Titles.Docent; break; }
                case "Старший преподаватель":
                    { this.Title = Titles.ElderTeacher; break; }
                case "Преподаватель":
                    { this.Title = Titles.Teacher; break; }
                case "Ассистент":
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
            result += this.getAcademicDegreeStr() + "|";
            result += this.getTitleStr() + "|";
            foreach (var item in CourseWorkStudents)
                result += item.getName() + "&";
            return result.Remove(result.LastIndexOf('&'));
        }
        public override string GetTypeName()
        {
            return this.GetType().Name;
        }
    }
}
