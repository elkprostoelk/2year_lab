using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class RAM : Device
    {
        public int Capacity { get; private set; }
        public int Frequency { get; private set; }
        public enum DDRTypes
        {
            None,
            DDR3,
            DDR4
        }
        public DDRTypes DDRType { get; private set; }
        public RAM() : base()
        {
            Capacity = 0;
            Frequency = 0;
            DDRType = DDRTypes.None;
        }
        public RAM(string manufacturername, string name, int price, int capacity, int frequency, DDRTypes ddrtype)
            : base(manufacturername,name,price)
        {
            Capacity = capacity;
            Frequency = frequency;
            DDRType = ddrtype;
        }
    }
}
