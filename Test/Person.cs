using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public abstract class Person
    {
        protected string Name;
        protected int Age;
        protected AddressField Address;
        public string getName() { return this.Name; }
        public void setName(string Name) { this.Name = Name; }
        public int getAge() { return this.Age; }
        public void setAge(int Age) { this.Age = Age; }
        public AddressField getAddress() { return this.Address; }
        public void setAddress(AddressField Address) { this.Address = Address; }
        protected Person()
        {
            Name = "xxx";
            Age = 0;
            Address = new AddressField();
        }
        protected Person(string name, int age, AddressField address)
        {
            Name=name;
            Age=age;
            Address=address;
        }
        public override string ToString()
        {
            return Name + "|" + Age + "|" + Address.ToString();
        }
    }
}
