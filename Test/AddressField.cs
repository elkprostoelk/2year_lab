using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class AddressField
    {
        public string Country { get; set; }
        public string Oblast { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public int Apartment { get; set; }
        public AddressField()
        {
            Country = "Ukraine";
            Oblast = "Khersonska";
            Region = "Khersonsky";
            City = "Kherson";
            Street = "Universitetska";
            HomeNumber = "27";
            Apartment = 0;
        }
        public AddressField(string fullAddress)
        {
            string[] splitted = fullAddress.Split(' ');
            Country = splitted[0];
            Oblast = splitted[1];
            if(splitted.Length==7)
            {
                Region = splitted[2];
                City = splitted[3];
                Street = splitted[4];
                HomeNumber = splitted[5];
                Apartment = int.Parse(splitted[6]);
            }
            else
            {
                Region = "";
                City = splitted[2];
                Street = splitted[3];
                HomeNumber = splitted[4];
                Apartment = int.Parse(splitted[5]);
            }
        }
        public AddressField(string country, string oblast, string region, string city, string street, string homenum, int apartment)
        {
            Country = country;
            Oblast = oblast;
            Region = region;
            City = city;
            Street = street;
            HomeNumber = homenum;
            Apartment = apartment;
        }
        public override string ToString()
        {
            string address = "";
            address += Country + " ";
            address += Oblast + " ";
            if (!string.IsNullOrWhiteSpace(Region)) address += Region + " ";
            address += City + " ";
            address += HomeNumber + " ";
            address += Street + " ";
            address += Apartment;
            return address;
        }
        public static bool operator ==(AddressField a, AddressField b)
        {
            return a.Country == b.Country && a.Oblast == b.Oblast && a.Region == b.Region && a.City == b.City && a.Street == b.Street && a.HomeNumber == b.HomeNumber && a.Apartment == b.Apartment;
        }
        public static bool operator !=(AddressField a, AddressField b)
        {
            return a.Country != b.Country || a.Oblast != b.Oblast || a.Region != b.Region || a.City != b.City || a.Street != b.Street || a.HomeNumber != b.HomeNumber || a.Apartment != b.Apartment;
        }
    }
}
