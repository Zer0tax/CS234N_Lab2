/* Author:  Eric Robinson L00709820
  * Date:    10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Define Product object.
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        // Instance variables
        string productCode;
        string description;
        decimal unitPrice;
        int onHandQuantity;

        // Default constructor
        public Product() 
        {
            // Assign a meaningless product code.
            // We do this because the ProductCode setter will not permit a null ProductCode. REALLY???
            // Note that ProductCode is defined in the database table as 10 chars long.
            // ProductCode = "zzzzzzzzzz";
        }

        // Full Constructor
        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }

        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if ((value != null) && (value.Length > 0) && (value.Length <= 10)) // Product code must be 1 - 10 chars long.
                    productCode = value;
                else
                    throw new ArgumentOutOfRangeException("ProductCode is a required value.");
            }
        } // end ProductCode

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if ((value != null) && (value.Length > 0) && (value.Length <= 50))
                // if (value.Length <= 50)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("Please shorten the description. Max length is 50 characters.");
            }
        } // end Description

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value >= 0)
                    unitPrice = value;
                else
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }
        } // end UnitPrice

        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }
            set
            {
                if (value >= 0)
                    onHandQuantity = value;
                else
                    throw new ArgumentOutOfRangeException("OnHandQuantity cannot be negative.");
            }
        } // end OnHandQuantity

        public override string ToString()
        {
            // return base.ToString(); - what does this mean?
            return "ProductCode: " + productCode + ", " + "Description: " + description + ", " + "Unit Price: " + unitPrice + ", " + "On Hand Quantity: " + onHandQuantity;
        }

    } // end public class Product
} // end namespace MMABooksBusinessClasses
