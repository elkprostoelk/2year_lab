using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class Device
    {
        public string ManufacturerName { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        protected Device()
        {
            ManufacturerName = "";
            Name = "";
            Price = 0;
        }
        protected Device(string manufacturername, string name, int price)
        {
            ManufacturerName = manufacturername;
            Name = name;
            Price = price;
        }
    }
}
