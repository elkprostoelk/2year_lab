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
        public Dictionary<string, string> FileName { get; } = new Dictionary<string, string> { { "TXT", "data.txt" }, { "XML", "data.xml" }, { "JSON", "data.json" } };
        public PersonList()
        {
            People = new List<Person>();
        }
        public PersonList(PersonList personList)
        {
            this.People = new List<Person>();
            foreach (var item in personList.People)
                this.People.Add(item);
        }
        public List<Person> getList()
        {
            return People;
        }
        public void AddPerson(Person p)
        {
            People.Add(p);
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
                    this.AddPerson(new Teacher(current[0], int.Parse(current[1]), new AddressField(current[2]), sal, current[4], current[5]));
                else this.AddPerson(new Student(current[0], int.Parse(current[1]), new AddressField(current[2]), current[3], float.Parse(current[4]), float.Parse(current[5])));
            }
            sr.Close();
        }
        public void ExportInXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootelement = xmlDocument.CreateElement("people");
            xmlDocument.AppendChild(rootelement);
            foreach (var item in People)
            {
                XmlElement current = xmlDocument.CreateElement(item.GetType().Name);
                rootelement.AppendChild(current);
                XmlElement name = xmlDocument.CreateElement("name");
                XmlElement age = xmlDocument.CreateElement("age");
                XmlElement address = xmlDocument.CreateElement("address");
                XmlText nameTxt = xmlDocument.CreateTextNode(item.Name);
                XmlText ageTxt = xmlDocument.CreateTextNode(item.Age.ToString());
                XmlText addressTxt = xmlDocument.CreateTextNode(item.Address.ToString());
                current.AppendChild(name);
                current.AppendChild(age);
                current.AppendChild(address);
                name.AppendChild(nameTxt);
                age.AppendChild(ageTxt);
                address.AppendChild(addressTxt);
                //if(item.GetType().Name=="Student")
            }
            xmlDocument.Save(FileName["XML"]);
        }
    }
}
