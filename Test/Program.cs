using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student("Ivan Ivanov", 20, new AddressField("Ukraine", "Khersonska", "", "Kherson", "Universitetska", "126", 11), "state", 1300f, 87.4f, new CourseWork("Student-teacher app creating", "App for student-teacher conversation"));
            Teacher teacher1 = new Teacher("Petr Petrov", 49, new AddressField("Ukraine", "Khersonska", "", "Kherson", "200YearOfKherson", "25", 10), 4000f, 3, "Candidate of Sciences", "Docent");
            teacher1.AddCourseWorkStudent(std1);
            Console.WriteLine(std1.ToString());
            Console.WriteLine(teacher1.ToString());
            PersonList personList = new PersonList();
            personList.AddPersonRange(std1, teacher1);
            personList.ExportInTxt();
            personList.ExportInXml();
            Console.WriteLine("----------From TXT------------------");
            personList.ImportFromTxt();
            foreach (var item in personList.getList())
                Console.WriteLine(item.ToString());
            Console.WriteLine("----------From XML------------------");
            personList.ImportFromXml();
            foreach (var item in personList.getList())
                Console.WriteLine(item.ToString());
        }
    }
}
