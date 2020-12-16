using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class CPU : Device
    {
        public enum Sockets
        {
            None,
            sAM4,
            s1151,
            s1151v2,
            s1200
        }
        public Sockets Socket { get; set; }
        public int Frequency { get; set; }
        public int Cores { get; set; }
        public bool HyperThreading { get; set; }
        public CPU() : base()
        {
            Socket = Sockets.None;
            Frequency = 0;
            Cores = 0;
            HyperThreading = false;
        }
        public CPU(string manufacturername, string name, int price, Sockets socket, int frequency, int cores, bool hyperthreading)
            : base(manufacturername, name, price)
        {
            Socket = socket;
            Frequency = frequency;
            Cores = cores;
            HyperThreading = hyperthreading;
        }
    }
}
