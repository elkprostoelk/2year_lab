using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student("Ivan Ivanov", 20, new AddressField("Ukraine", "Khersonska", "", "Kherson", "Universitetska", "126", 11), "state", 1300f, 87.4f, new CourseWork("Student-teacher app creating", "App for student-teacher conversation"));
            Teacher teacher1 = new Teacher("Petr Petrov", 49, new AddressField("Ukraine", "Khersonska", "", "Kherson", "200 Year of Kherson", "25", 10), 4000f, 3, "Candidate of Sciences", "Docent");
            teacher1.AddCourseWorkStudent(std1);
            Console.WriteLine(std1.ToString());
            Console.WriteLine(teacher1.ToString());
            //personList.ExportInXml();
        }
    }
}
