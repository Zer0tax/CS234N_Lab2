/* Author:  Eric Robinson L00709820
 * 10/21/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Unit Tests of the ProductDB.
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
    public class ProductDBTests
    {
        string productCode = "";
        string book2 = "A4VB";  // This is the ProductCode of the 2nd row currently in the products table in our MySQL DB.

        private string RandomProductCode()
        // Source: https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        // Author: Dan Rigby
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct(book2);
            Assert.AreEqual(book2, p.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product p = new Product();
            string randomCode = RandomProductCode();  // Get a random product code. This allows us to avoid duplications when we run tests multiple times.
            p.ProductCode = randomCode;
            p.Description = "Lane CC CS234N Study Notes";
            p.UnitPrice = 99.99m;
            p.OnHandQuantity = 3;

            TestContext.WriteLine("randomCode: " + randomCode);
            TestContext.WriteLine("p.ProductCode: " + p.ProductCode);
            // TestContext.ReadKey();

            // int recordsAdded;
            int recordsAdded = ProductDB.AddProduct(p); // This line always gets zero. But I can't figure out why.
            // TestContext.WriteLine("productCode: " + productCode);
            p = ProductDB.GetProduct(randomCode);
            Assert.AreEqual(randomCode, p.ProductCode);
        }

        [Test]
        public void TestUpdateProduct()
        {
            string prodCode = "DB1R"; // We deliberatley choose a product without an apostrophe in its description.

            Product p = new Product();
            p.ProductCode = prodCode;
            p.Description = "Lab 2 Sample Answers";
            p.UnitPrice = 1.0m;
            p.OnHandQuantity = 1;

            // bool result = CustomerDB.UpdateCustomer(CustomerDB.GetCustomer(customerID), c);
            bool result = ProductDB.UpdateProduct(ProductDB.GetProduct(prodCode), p);  
            Assert.AreEqual("Lab 2 Sample Answers", p.Description);
        }

        [Test]
        public void TestDeleteProduct()
        {
            string prodCode = "3yc1oojtoR";

            Product p = ProductDB.GetProduct(prodCode);
            bool result = ProductDB.DeleteProduct(p);
            Assert.IsNull(ProductDB.GetProduct(prodCode));
        }

    } // end class ProductDBTests
} // end namespace MMABooksTests
