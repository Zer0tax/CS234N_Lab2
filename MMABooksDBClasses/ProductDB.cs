/* Author:  Lindy Stewart
 * Changes: Eric Robinson L00709820
 * 10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Conect to MMABooksDB
 */

/* @varName is a placeholder for user supplied values.
 * Using @ helps prevent SQL injection attacks.
 */

using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;
using Microsoft.VisualBasic;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];  // ToDecimal???
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"]; // ToInteger???
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end GetProduct()

        public static int AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            try
            {
                connection.Open();
                int rowsAdded = insertCommand.ExecuteNonQuery();
                return rowsAdded;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end AddProduct()

        public static bool DeleteProduct(Product p)  
        {
            // Get a connection to the database.
            MySqlConnection connection = MMABooksDB.GetConnection();

            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " + 
                " AND Description =  @Description " + 
                " AND UnitPrice = @UnitPrice " + 
                " AND OnHandQuantity =  @OnHandQuantity";

            // Set up the command object.
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);

            // Insert actual values into the delete statement.
            deleteCommand.Parameters.AddWithValue(
                "@ProductCode", p.ProductCode);
            deleteCommand.Parameters.AddWithValue(
                "@Description", p.Description);
            deleteCommand.Parameters.AddWithValue(
                "@UnitPrice", p.UnitPrice);
            deleteCommand.Parameters.AddWithValue(
                "@OnHandQuantity", p.OnHandQuantity);
            
            // throw new Exception(deleteStatement);
 
            try
            {
                // Open the connection.
                connection.Open ();

                // deleteCommand.ExecuteNonQuery();
                // object result = deleteCommand.ExecuteScalar();
                // int r = Convert.ToInt32(result);

                // Execute the command.
                // r stores the number of rows deleted. I hope!
                int r = Convert.ToInt32(deleteCommand.ExecuteScalar());
                
                // If the number of records returned = 1, return true otherwise return false.
                if (r == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end DeleteProduct()

        public static bool UpdateProduct(Product oldProd, Product newProd)
        {
            // Get a connection to the database.
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement =
                "UPDATE Products SET " +
                "ProductCode = @ProductCode, " +
                "Description = @Description, " +
                "UnitPrice = @UnitPrice, " +
                "OnHandQuantity = @OnHandQuantity " +
                "WHERE ProductCode = " + "'" + oldProd.ProductCode + "'" +
                " AND Description = " + "'" + oldProd.Description + "'" +
                " AND UnitPrice = " + "'" + oldProd.UnitPrice + "'" + 
                " AND OnHandQuantity = " + "'" + oldProd.OnHandQuantity + "'";

            // Setup the command object.
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);

            // oldProduct values are already in the database. I don't think we have to sanitize them.
            updateCommand.Parameters.AddWithValue("@ProductCode", newProd.ProductCode);
            updateCommand.Parameters.AddWithValue("@Description", newProd.Description);
            updateCommand.Parameters.AddWithValue("@UnitPrice", newProd.UnitPrice);
            updateCommand.Parameters.AddWithValue("@OnHandQuantity", newProd.OnHandQuantity);

            // throw new Exception(updateStatement);

            try
            {
                // Open the connection.
                connection.Open();

                // Execute the command.
                // r stores the number of rows deleted. I hope!
                int r = Convert.ToInt32(updateCommand.ExecuteScalar());
                
                // if the number of records returned = 1, return true otherwise return false
                if (r == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end UpdateProduct()

    } // end public static class ProductDB
} // end namespace MMABooksDBClasses
