using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture.Models
{
    public class PSU : Device
    {
        public int Power { get; private set; }
        public int MaxVideocardsCount { get; private set; }
        public int MaxStoragesCount { get; private set; }
        public Certificates80Plus Certificate80Plus { get; private set; }
        public enum Certificates80Plus
        {
            None,
            Bronze,
            Silver,
            Gold,
            Platinum,
            Titanium
        }
        public PSU() : base()
        {
            Power = 0;
            MaxVideocardsCount = 0;
            MaxStoragesCount = 0;
            Certificate80Plus = Certificates80Plus.None;
        }
        public PSU(string manufacturername, string name, int price, int power, int maxvideocardscount, int maxstoragescount, Certificates80Plus certificate80plus)
            : base(manufacturername, name, price)
        {
            Power = power;
            MaxVideocardsCount = maxvideocardscount;
            MaxStoragesCount = maxstoragescount;
            Certificate80Plus = certificate80plus;
        }
    }
}
