using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Test
{
    public class PersonList
    {
        private List<Person> People;
        private Dictionary<string, string> FileName { get; } = new Dictionary<string, string>
        { { "TXT", "data.txt" },
            { "XML", "data.xml" }};
        public PersonList()
        {
            People = new List<Person>();
        }
        public List<Person> getList()
        {
            return People;
        }
        public int AddPerson(Person p)
        {
            People.Add(p);
            return People.IndexOf(p);
        }
        public int[] AddPersonRange(params Person[] people)
        {
            int[] indexes = new int[people.Length];
            foreach (var item in people)
                this.AddPerson(item);
            return indexes;
        }
        public void RemovePerson(int index)
        {
            People.RemoveAt(index);
        }
        public PersonList FindPersonByName(string name)
        {
            PersonList found = new PersonList();
            foreach (var item in People)
                if (item.Name.Contains(name)) found.AddPerson(item);
            return found;
        }
        public void ExportInTxt()
        {
            StreamWriter sw = new StreamWriter(FileName["TXT"]);
            foreach (var item in People)
                sw.WriteLine(item.ToString());
            sw.Close();
        }
        public void ImportFromTxt()
        {
            People.Clear();
            StreamReader sr = new StreamReader(FileName["TXT"]);
            while (!sr.EndOfStream)
            {
                string[] current = sr.ReadLine().Split('|');
                if (float.TryParse(current[3], out float sal))
                {
                    Teacher t= new Teacher(current[0], int.Parse(current[1]),
                          new AddressField(current[2]), sal, int.Parse(current[4]), current[5], current[6]);
                    foreach (var item in current[7].Split('&'))
                        for (int i = 0; i < FindPersonByName(item).People.Count; i++)
                            t.CourseWorkStudents.Add((Student)FindPersonByName(item).People[i]);
                    this.AddPerson(t);
                }
                else this.AddPerson(new Student(current[0], int.Parse(current[1]), new AddressField(current[2]),
                        current[3], float.Parse(current[4]), float.Parse(current[5]),
                        new CourseWork(current[6].Split('$')[0], current[6].Split('$')[1])));
            }
            sr.Close();
        }
        public void ExportInXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootelement = xmlDocument.CreateElement("People");
            xmlDocument.AppendChild(rootelement);
            for (int i = 0; i < People.Count; i++)
            {
                XmlElement current = xmlDocument.CreateElement(People[i].GetType().Name);
                rootelement.AppendChild(current);
                XmlElement name = xmlDocument.CreateElement("Name");
                XmlElement age = xmlDocument.CreateElement("Age");
                XmlElement address = xmlDocument.CreateElement("AddressField");
                XmlText nameTxt = xmlDocument.CreateTextNode(People[i].Name);
                XmlText ageTxt = xmlDocument.CreateTextNode(People[i].Age.ToString());
                XmlText addressTxt = xmlDocument.CreateTextNode(People[i].Address.ToString());
                current.AppendChild(name);
                current.AppendChild(age);
                current.AppendChild(address);
                name.AppendChild(nameTxt);
                age.AppendChild(ageTxt);
                address.AppendChild(addressTxt);
                switch (People[i].GetType().Name)
                {
                    case "Student":
                        {
                            Student student = (Student)People[i];
                            XmlElement isState = xmlDocument.CreateElement("isState");
                            XmlElement Scholarship = xmlDocument.CreateElement("Scholarship");
                            XmlElement AverageBall = xmlDocument.CreateElement("AverageBall");
                            XmlElement courseWork = xmlDocument.CreateElement("courseWork");
                            XmlText isStateTxt = xmlDocument.CreateTextNode(student.isState.ToString());
                            XmlText ScholarshipTxt = xmlDocument.CreateTextNode(student.Scholarship.ToString());
                            XmlText AverageBallTxt = xmlDocument.CreateTextNode(student.AverageBall.ToString());
                            XmlText courseWorkTxt = xmlDocument.CreateTextNode(student.courseWork.ToString());
                            current.AppendChild(isState);
                            current.AppendChild(Scholarship);
                            current.AppendChild(AverageBall);
                            current.AppendChild(courseWork);
                            isState.AppendChild(isStateTxt);
                            Scholarship.AppendChild(ScholarshipTxt);
                            AverageBall.AppendChild(AverageBallTxt);
                            courseWork.AppendChild(courseWorkTxt);
                            break;
                        }
                    case "Teacher":
                        {
                            Teacher teacher = (Teacher)People[i];
                            XmlElement salary = xmlDocument.CreateElement("Salary");
                            XmlElement MaxNumberOfCourseWorks = xmlDocument.CreateElement("MaxNumberOfCourseWorks");
                            XmlElement AcademicDegree = xmlDocument.CreateElement("AcademicDegree");
                            XmlElement Title = xmlDocument.CreateElement("Title");
                            XmlElement CourseWorkStudents = xmlDocument.CreateElement("CourseWorkStudents");
                            XmlText SalaryTxt = xmlDocument.CreateTextNode(teacher.Salary.ToString());
                            XmlText MaxNumberOfCourseWorksTxt = xmlDocument.CreateTextNode(teacher.MaxNumberOfCourseWorks.ToString());
                            XmlText AcademicDegreeTxt = xmlDocument.CreateTextNode(teacher.AcademicDegree);
                            XmlText TitleTxt = xmlDocument.CreateTextNode(teacher.Title);
                            string courseworkers = "";
                            foreach (var student in teacher.CourseWorkStudents)
                                courseworkers += student.Name + "&";
                            courseworkers=courseworkers.Remove(courseworkers.LastIndexOf('&'));
                            XmlText courseWorkStudentsTxt = xmlDocument.CreateTextNode(courseworkers);
                            current.AppendChild(salary);
                            current.AppendChild(MaxNumberOfCourseWorks);
                            current.AppendChild(AcademicDegree);
                            current.AppendChild(Title);
                            current.AppendChild(CourseWorkStudents);
                            salary.AppendChild(SalaryTxt);
                            MaxNumberOfCourseWorks.AppendChild(MaxNumberOfCourseWorksTxt);
                            AcademicDegree.AppendChild(AcademicDegreeTxt);
                            Title.AppendChild(TitleTxt);
                            CourseWorkStudents.AppendChild(courseWorkStudentsTxt);
                            break;
                        }
                    default:
                        break;
                }
            }
            xmlDocument.Save(FileName["XML"]);
        }
        public void ImportFromXml()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(FileName["XML"]);
            People.Clear();
            foreach (XmlNode element in xml.ChildNodes[0].ChildNodes)
            {
                switch (element.Name)
                {
                    case "Student":
                        {
                            Student student = new Student();
                            student.Name = element.ChildNodes[0].InnerText;
                            student.Age = int.Parse(element.ChildNodes[1].InnerText);
                            student.Address = new AddressField(element.ChildNodes[2].InnerText);
                            student.isState = bool.Parse(element.ChildNodes[3].InnerText);
                            student.Scholarship = float.Parse(element.ChildNodes[4].InnerText);
                            student.AverageBall = float.Parse(element.ChildNodes[5].InnerText);
                            student.courseWork = new CourseWork(element.ChildNodes[6].InnerText.Split('$')[0], element.ChildNodes[6].InnerText.Split('$')[1]);
                            People.Add(student);
                            break;
                        }
                    case "Teacher":
                        {
                            Teacher teacher = new Teacher(element.ChildNodes[0].InnerText,
                                int.Parse(element.ChildNodes[1].InnerText),
                                new AddressField(element.ChildNodes[2].InnerText),
                                float.Parse(element.ChildNodes[3].InnerText),
                                int.Parse(element.ChildNodes[4].InnerText),
                                element.ChildNodes[5].InnerText,
                                element.ChildNodes[6].InnerText);
                            foreach (var item in element.ChildNodes[7].InnerText.Split('&'))
                                foreach (Student stud in FindPersonByName(item).getList())
                                    teacher.AddCourseWorkStudent(stud);
                            People.Add(teacher);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
