using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class GPU : Device
    {
        public int VRAMCapacity { get; private set; }
        public int MinPSUPower { get; private set; }
        public bool SupportsRTX { get; private set; }
        public GPU() : base()
        {
            VRAMCapacity = 0;
            SupportsRTX = false;
        }
        public GPU(string manufacturername, string name, int price, int vramcapacity, bool supportsrtx)
            : base(manufacturername,name,price)
        {
            VRAMCapacity = vramcapacity;
            SupportsRTX = supportsrtx;
        }
    }
}
