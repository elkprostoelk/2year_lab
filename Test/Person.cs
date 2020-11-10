using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AddressField Address { get; set; }
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
        public static bool operator ==(Person a, Person b)
        {
            return a.Name == b.Name && a.Age == b.Age && a.Address == b.Address;
        }
        public static bool operator !=(Person a, Person b)
        {
            return a.Name != b.Name || a.Age != b.Age || a.Address != b.Address;
        }
    }
}
