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
        private readonly Dictionary<string, string> FileName = new Dictionary<string, string>
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
        /*public void RecountIds()
        {
            for (int i = 0; i < People.Count; i++)
                People[i].setId(i);
        }*/
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
                if (item.getName().Contains(name)) found.AddPerson(item);
            return found;
        }
        public void ExportInTxt()
        {
            using (StreamWriter sw = new StreamWriter(FileName["TXT"]))
            {
                foreach (var item in People)
                    sw.WriteLine(item.ToString());
            }
        }
        public void ImportFromTxt()
        {
            People.Clear();
            using (StreamReader sr = new StreamReader(FileName["TXT"]))
            { 
                while (!sr.EndOfStream)
                {
                    string[] current = sr.ReadLine().Split('|');
                    switch(current[0])
                    {
                        case "Teacher":
                        {
                            Teacher t = new Teacher(current[1], int.Parse(current[2]),
                                    new AddressField(current[3]), float.Parse(current[4]), int.Parse(current[5]), current[6], current[7]);
                            foreach (var item in current[8].Split('&'))
                                for (int i = 0; i < FindPersonByName(item).People.Count; i++)
                                    t.getCourseWorkStudents().Add((Student)FindPersonByName(item).People[i]);
                            this.AddPerson(t);
                            break;
                        }
                        case "Student":
                        {
                            Student s = new Student(current[1], int.Parse(current[2]), new AddressField(current[3]),
                            current[4], current[5], current[6], float.Parse(current[7]), float.Parse(current[8]),
                            new CourseWork(current[9].Split('$')[0], current[9].Split('$')[1]));
                            this.AddPerson(s);
                            break;
                        }
                        default: break;
                    }
                    
                }
            }
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
                XmlElement country = xmlDocument.CreateElement("Country");
                XmlElement oblast = xmlDocument.CreateElement("Oblast");
                XmlElement region = xmlDocument.CreateElement("Region");
                XmlElement city = xmlDocument.CreateElement("City");
                XmlElement street = xmlDocument.CreateElement("Street");
                XmlElement homenumber = xmlDocument.CreateElement("HomeNumber");
                XmlElement apartment = xmlDocument.CreateElement("Apartment");
                XmlText nameTxt = xmlDocument.CreateTextNode(People[i].getName());
                XmlText ageTxt = xmlDocument.CreateTextNode(People[i].getAge().ToString());
                XmlText countryTxt = xmlDocument.CreateTextNode(People[i].getAddress().getCountry());
                XmlText oblastTxt = xmlDocument.CreateTextNode(People[i].getAddress().getOblast());
                XmlText regionTxt = xmlDocument.CreateTextNode(People[i].getAddress().getRegion());
                XmlText cityTxt = xmlDocument.CreateTextNode(People[i].getAddress().getCity());
                XmlText streetTxt = xmlDocument.CreateTextNode(People[i].getAddress().getStreet());
                XmlText homeNumberTxt = xmlDocument.CreateTextNode(People[i].getAddress().getHomeNumber());
                XmlText apartmentTxt = xmlDocument.CreateTextNode(People[i].getAddress().getApartment().ToString());
                current.AppendChild(name);
                current.AppendChild(age);
                current.AppendChild(address);
                name.AppendChild(nameTxt);
                age.AppendChild(ageTxt);
                address.AppendChild(country);
                address.AppendChild(oblast);
                address.AppendChild(region);
                address.AppendChild(city);
                address.AppendChild(street);
                address.AppendChild(homenumber);
                address.AppendChild(apartment);
                country.AppendChild(countryTxt);
                oblast.AppendChild(oblastTxt);
                region.AppendChild(regionTxt);
                city.AppendChild(cityTxt);
                street.AppendChild(streetTxt);
                homenumber.AppendChild(homeNumberTxt);
                apartment.AppendChild(apartmentTxt);
                switch (People[i].GetType().Name)
                {
                    case "Student":
                        {
                            Student student = (Student)People[i];
                            XmlElement Faculty = xmlDocument.CreateElement("Faculty");
                            XmlElement Group = xmlDocument.CreateElement("Group");
                            XmlElement isState = xmlDocument.CreateElement("isState");
                            XmlElement Scholarship = xmlDocument.CreateElement("Scholarship");
                            XmlElement AverageBall = xmlDocument.CreateElement("AverageBall");
                            XmlElement courseWork = xmlDocument.CreateElement("courseWork");
                            XmlText FacultyTxt = xmlDocument.CreateTextNode(student.getFaculty());
                            XmlText GroupTxt = xmlDocument.CreateTextNode(student.getGroup());
                            XmlText isStateTxt = xmlDocument.CreateTextNode(student.getIsState().ToString());
                            XmlText ScholarshipTxt = xmlDocument.CreateTextNode(student.getScholarship().ToString());
                            XmlText AverageBallTxt = xmlDocument.CreateTextNode(student.getAverageBall().ToString());
                            XmlText courseWorkTxt = xmlDocument.CreateTextNode(student.getCourseWork().ToString());
                            current.AppendChild(Faculty);
                            current.AppendChild(Group);
                            current.AppendChild(isState);
                            current.AppendChild(Scholarship);
                            current.AppendChild(AverageBall);
                            current.AppendChild(courseWork);
                            Faculty.AppendChild(FacultyTxt);
                            Group.AppendChild(GroupTxt);
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
                            XmlText SalaryTxt = xmlDocument.CreateTextNode(teacher.getSalary().ToString());
                            XmlText MaxNumberOfCourseWorksTxt = xmlDocument.CreateTextNode(teacher.getMaxNumberOfCourseWorks().ToString());
                            XmlText AcademicDegreeTxt = xmlDocument.CreateTextNode(teacher.getAcademicDegreeStr());
                            XmlText TitleTxt = xmlDocument.CreateTextNode(teacher.getTitleStr());
                            string courseworkers = "";
                            foreach (var student in teacher.getCourseWorkStudents())
                                courseworkers += student.getName() + "&";
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
                            student.setName(element.ChildNodes[0].InnerText);
                            student.setAge(int.Parse(element.ChildNodes[1].InnerText));
                            student.setAddress(new AddressField(element.ChildNodes[2].ChildNodes[0].InnerText, element.ChildNodes[2].ChildNodes[1].InnerText,
                                element.ChildNodes[2].ChildNodes[2].InnerText, element.ChildNodes[2].ChildNodes[3].InnerText, element.ChildNodes[2].ChildNodes[4].InnerText,
                                element.ChildNodes[2].ChildNodes[5].InnerText, int.Parse(element.ChildNodes[2].ChildNodes[6].InnerText)));
                            student.setFaculty(element.ChildNodes[3].InnerText);
                            student.setGroup(element.ChildNodes[4].InnerText);
                            student.setIsState(bool.Parse(element.ChildNodes[5].InnerText));
                            student.setScholarship(float.Parse(element.ChildNodes[6].InnerText));
                            student.setCourseWork(new CourseWork(element.ChildNodes[7].InnerText.Split('$')[0], element.ChildNodes[7].InnerText.Split('$')[1]));
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
