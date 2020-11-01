using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(), std2 = new Student();
            Console.WriteLine(std1 == std2);
            PersonList personList = new PersonList();
            personList.AddPerson(std1);
            personList.AddPerson(std2);
            personList.ExportInXml();
        }
    }
}
