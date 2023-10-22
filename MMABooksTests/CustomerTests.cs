/* Author:  Eric Robinson L00709820
 * Date:    10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Test Customer.cs
 */

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer cust0; // Our default customer
        private Customer cust1;
        private Customer cust2;

        [SetUp]
        public void Setup()
        {
            cust0 = new Customer();
            cust1 = new Customer(1, "Ada Lovelace", "4000 E 30th Ave.","Eugene", "OR", "97405");
            // cust2 = new Customer(2, "Greta Thunberg", "123 Sweden Way", "Stockholm", "DE", "01234");
        }

        [Test]
        public void TestConstructor() 
        {
            Assert.IsNotNull(cust0);
            Assert.AreEqual(null, cust0.Name);
            Assert.AreEqual(null, cust0.Address);
            Assert.AreEqual(null, cust0.City);
            Assert.AreEqual(null, cust0.State);
            Assert.AreEqual(null, cust0.ZipCode);

            Assert.IsNotNull(cust1);
            Assert.AreNotEqual(null, cust1.Name);
            Assert.AreNotEqual(null, cust1.Address);
            Assert.AreNotEqual(null, cust1.City);
            Assert.AreNotEqual(null, cust1.State); 
            Assert.AreNotEqual(null, cust1.ZipCode);
        }

        [Test]
        public void TestCustomerSetter()
        {
            int custNum = 2;
            string custName = "Grace Hopper";
            string address = "1010 Army Pentagon";
            string city = "Washington";
            string state = "DC";
            string zipCode = "20310-0101";

            // Call the setters.
            cust1.CustomerID = custNum;
            cust1.Name = custName;
            cust1.Address = address;
            cust1.City = city;
            cust1.State = state;
            cust1.ZipCode = zipCode;

            // Assert that the property returns the expected values.
            Assert.AreEqual(custNum, cust1.CustomerID);
            Assert.AreEqual(custName, cust1.Name);
            Assert.AreEqual(address, cust1.Address);
            Assert.AreEqual(city, cust1.City);
            Assert.AreEqual(state, cust1.State);
            Assert.AreEqual(zipCode, cust1.ZipCode);
        }

        // I dont know how to test if ID is a non-integer.

        [Test]
        public void TestSetterForNameWith101Chars()
        {
            try
            {
                // Customer name must be <=100 chars so we will try 101.
                cust1.Name = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForAddressWith51Chars()
        {
            try
            {
                // Customer address must be <=50 chars so we will try 51.
                cust1.Address = "123456789012345678901234567890123456789012345678901";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForCityWith21Chars()
        {
            try
            {
                // Customer city must be <=20 chars so we will try 21.
                cust1.City = "123456789012345678901";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForStateWith3Chars()
        {
            try
            {
                // Customer state must be 2 chars so we will try 3.
                cust1.State = "123";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForZipWith16Chars()
        {
            try
            {
                // Customer zip must be <=15 chars so we will try 16.
                cust1.ZipCode = "1234567890123456";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

    } // end class CustomerTests
} // end namespace MMABooksTests
