/* Author:  Eric Robinson L00709820
 * Date:    10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Define Customer object.
 */

using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // There are several warnings in this file related to nullable properties and return values.
        // You can ignore them.

        // Default constructor
        public Customer() 
        {
            // Assign highest possible value to ID.
            // We do this because the CustomerID setter will not permit a null CustomerID.
            // Note that ID is defined in the database table as 10 chars long.
            CustomerID = Int32.MaxValue;
        } 

        // Full constructor
        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        // Instance Variables
        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipCode;

        public int CustomerID 
        { 
            get
            {
                return customerID;
            }
            
          set
            {
                // What should we do if the customer is null?
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("CustomerID must be a positive integer.");
            }
        } // end CustomerID

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name must be > 0 and <= 100 characters long.");
            }
        } // end Name

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    address = value;
                else
                    throw new ArgumentOutOfRangeException("Address must be > 0 and <= 50 characters long.");
            }
        } // end Address

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 20)
                    city = value;
                else
                    throw new ArgumentOutOfRangeException("City must be > 0 and <= 20 characters long.");
            }
        } // end City


        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value.Trim().Length == 2)
                    state = value;
                else
                    throw new ArgumentOutOfRangeException("Stae Code be 2 characters long, e.g., 'NY'.");
            }
        } // end State

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (value.Trim().Length > 4 && value.Trim().Length <= 15)
                    zipCode = value;
                else
                    throw new ArgumentOutOfRangeException("Zip Code must be between 5 and 15 characters long.");
            }
        } // end ZipCode

        public override string ToString()
        {
            // return base.ToString(); - what does this mean?
            return customerID + ", " + name + ", " + address + ", " + city + ", " + state + ", " + zipCode;
        }

    } // end public class Customer
} // end namespace MMABooksBusinessClasses
