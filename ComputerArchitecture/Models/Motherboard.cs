using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class Motherboard : Device
    {
        public CPU.Sockets Socket { get; private set; }
        public string Chipset { get; private set; }
        public int SlotsOfDRAM { get; private set; }
        public int MaxDRAMFrequency { get; private set; }
        public Motherboard() : base()
        {
            Socket = CPU.Sockets.None;
            Chipset = "";
            SlotsOfDRAM = 0;
            MaxDRAMFrequency = 0;
        }
        public Motherboard(string manufacturername, string name, int price, CPU.Sockets socket, string chipset, int slotsofdram, int maxdramfrequency)
            : base(manufacturername, name, price)
        {
            Socket = socket;
            Chipset = chipset;
            SlotsOfDRAM = slotsofdram;
            MaxDRAMFrequency = maxdramfrequency;
        }
    }
}
