using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        //data validation only checking state code and zip code
        private string state;
        public string State {
            get 
            { 
                return state; 
            }
            set 
            { 
                if(value.Length <=2)
                    state = value.ToUpper(); 
                else
                    throw new ArgumentOutOfRangeException("The state code must be exactly 2 characters.");

            } 
        }

        private string zipCode;
        public string ZipCode 
        {
            get { return zipCode; }
            set 
            {
                if(value.Length ==10)
                    zipCode = value; 
                else if(value.Length ==5)
                    zipCode = value;
                else
                    throw new ArgumentOutOfRangeException("The zip code must be 5 or 10 characters.");
            }
        }

        public override string ToString()
        {
            return CustomerID.ToString() + ", " + Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
        }
    }
}
