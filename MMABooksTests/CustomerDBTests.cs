/* Author:  Lindy Stewart
 * Changes: Eric Robinson L00709820
 * 10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Unit Tests of the CustomerDB.
 */

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {
        int customerID = 0;

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(2);
            Assert.AreEqual(2, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestUpdateCustomer() 
        {
            Customer c = new Customer();
            c.Name = "Minnie Mouse";
            c.Address = "102 Main Street";
            c.City = "Tucson";
            c.State = "AZ";
            c.ZipCode = "85720";

            // bool result = CustomerDB.UpdateCustomer(CustomerDB.GetCustomer(customerID), c);
            bool result = CustomerDB.UpdateCustomer(CustomerDB.GetCustomer(700), c);
            Assert.AreEqual("Minnie Mouse", c.Name);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            // We might still have a customerID in memory if we just ran TestCreateCustomer?
            if (customerID == 0)
                customerID = 700;  // We need to change this number each time we run a test.
            Customer c = CustomerDB.GetCustomer(customerID);
            bool result = CustomerDB.DeleteCustomer(c);
            Assert.IsNull(CustomerDB.GetCustomer(customerID));
        }

    } // class CustomerDBTests
} // end namespace MMABooksTests
