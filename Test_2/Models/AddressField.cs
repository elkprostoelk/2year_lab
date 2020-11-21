using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class AddressField
    {
        private string Country;
        private string Oblast;
        private string Region;
        private string City;
        private string Street;
        private string HomeNumber;
        private int Apartment;
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
        public string getCountry() { return this.Country; }
        public void setCountry(string Country) { this.Country = Country; }
        public string getOblast() { return this.Oblast; }
        public void setOblast(string Oblast) { this.Oblast = Oblast; }
        public string getRegion() { return this.Region; }
        public void setRegion(string Region) { this.Region = Region; }
        public string getCity() { return this.City; }
        public void setCity(string City) { this.City = City; }
        public string getStreet() { return this.Street; }
        public void setStreet(string Street) { this.Street = Street; }
        public string getHomeNumber() { return this.HomeNumber; }
        public void setHomeNumber(string HomeNumber) { this.HomeNumber = HomeNumber; }
        public int getApartment() { return this.Apartment; }
        public void setApartment(int Apartment) { this.Apartment = Apartment; }
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
    }
}
