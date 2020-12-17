using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Person
    {
        protected int Id;
        protected string Name;
        protected int Age;
        protected AddressField Address;
        public int getId() { return this.Id; }
        public void setId(int id) { this.Id = id; }
        public string getName() { return this.Name; }
        public void setName(string Name) { this.Name = Name; }
        public int getAge() { return this.Age; }
        public void setAge(int Age) { this.Age = Age; }
        public AddressField getAddress() { return this.Address; }
        public void setAddress(AddressField Address) { this.Address = Address; }
        public Person()
        {
            Id = 0;
            Name = "xxx";
            Age = 0;
            Address = new AddressField();
        }
        protected Person(string name, int age, AddressField address)
        {
            Id = 0;
            Name=name;
            Age=age;
            Address=address;
        }
        public override string ToString()
        {
            return Name + "|" + Age + "|" + Address.ToString();
        }
        public virtual string GetTypeName()
        {
            return "";
        }
    }
}
