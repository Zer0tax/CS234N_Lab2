/* Eric Robinson L00709820
 * 10/15/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Unit Tests of the Product class.
 */

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product prod0; // Our default product
        private Product prod1;
        private Product prod2;

        [SetUp]
        public void Setup()
        {
            prod0 = new Product();
            prod1 = new Product("ABC1", "How to Succeed in College Without Really Trying", 10m, 25); // m = decimal
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(prod0);
            Assert.AreEqual(null,prod0.Description);
            Assert.AreEqual(0, prod0.UnitPrice);
            Assert.AreEqual(0, prod0.OnHandQuantity);

            Assert.IsNotNull(prod1);
            Assert.AreEqual("How to Succeed in College Without Really Trying", prod1.Description);
            Assert.AreEqual(10m, prod1.UnitPrice);
            Assert.AreEqual(25, prod1.OnHandQuantity);
        }

        [Test]
        public void TestProductSetter()
        {
            string productCode = "XYZ9";
            string description = "Unit Testing for Dummies";
            decimal unitPrice = 25.0m;
            int onHandQuantity = 500;

            // Call the setters.
            prod1.ProductCode = productCode;
            prod1.Description = description;
            prod1.UnitPrice = unitPrice;
            prod1.OnHandQuantity = onHandQuantity;

            // Assert that the property returns the expected values.
            Assert.AreEqual(productCode, prod1.ProductCode);
            Assert.AreEqual(description, prod1.Description);
            Assert.AreEqual(unitPrice, prod1.UnitPrice);
            Assert.AreEqual(onHandQuantity, prod1.OnHandQuantity);
        }

        [Test]
        public void TestSetterFor11CharProductCode()
        {
            try
            {
                // ProductCode must be <= 10 chars so we will try 11.
                prod1.ProductCode = "12345678901";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterFor51CharDescription()
        {
            try
            {
                // Description must be <= 50 chars so we will try 51.
                prod1.Description = "123456789012345678901234567890123456789012345678901";
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForNegativelUnitPrice()
        {
            try
            {
                // UnitPrice must be >= 0 so we will try a negative value.
                prod1.UnitPrice = -1m;
                Assert.Fail("If the exception is NOT thrown, the test fails. UnitPrice = " + prod1.UnitPrice);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

        [Test]
        public void TestSetterForNegativelOnHandQuantity()
        {
            try
            {
                // OnHandQuantity must be >=0 so we will try a negative value.
                prod1.OnHandQuantity = -1;
                Assert.Fail("If the exception is NOT thrown, the test fails.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Pass("If the exception is thrown, the test passes.");
            }
        }

    } // end public class ProductTests
} // end namespace MMABooksTests

