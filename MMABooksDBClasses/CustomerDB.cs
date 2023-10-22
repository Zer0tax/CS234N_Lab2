/* Author:  LindyStewart
 * Changes: Eric Robinson L00709820
 * Date:    10/17/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Connect to MMABooksDB
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

namespace MMABooksDBClasses
{
    public static class CustomerDB
    {

        public static Customer GetCustomer(int customerID)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            
            string selectStatement
                = "SELECT CustomerID, Name, Address, City, State, ZipCode "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID"; 
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);  // Return a single row.
                if (custReader.Read())
                {
                    // Create Customer object.
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.Name = custReader["Name"].ToString();
                    customer.Address = custReader["Address"].ToString();
                    customer.City = custReader["City"].ToString();
                    customer.State = custReader["State"].ToString();
                    customer.ZipCode = custReader["ZipCode"].ToString();
                    return customer;
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
        } // end Customer GetCustomer()

        public static int AddCustomer(Customer customer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            MySqlCommand insertCommand = new MySqlCommand(insertStatement, connection);

            // Insert actual values into the insertion statement.
            insertCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            insertCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            insertCommand.Parameters.AddWithValue(
                "@City", customer.City);
            insertCommand.Parameters.AddWithValue(
                "@State", customer.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);

            try
            {
                connection.Open();

                // .ExecuteNonQuery indicates that our command does not return any records.
                // I think this is the 1 line of code that actually ADDS THE CUSTOMER!
                insertCommand.ExecuteNonQuery();

                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()"; 
                MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);

                // ExecuteScalar tells us that we will only get back 1 value.
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID; // What do we think the calling method will do with this value???
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end AddCustomer()

        public static bool DeleteCustomer(Customer customer)
        {
            // Get a connection to the database.
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";

            // Set up the command object.
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);

            // Insert actual values into the delete statement.
            deleteCommand.Parameters.AddWithValue(
                "@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue(
                "@City", customer.City);
            deleteCommand.Parameters.AddWithValue(
                "@State", customer.State);
            deleteCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            // throw new Exception(Convert.ToString(customer.CustomerID));

            try
            {
                 connection.Open();

                // Execute the command.
                int r = Convert.ToInt32(deleteCommand.ExecuteScalar());

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
        } // end DeleteCustomer()

        public static bool UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            // Create a connection.
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = " + "'" + oldCustomer.CustomerID + "'" + 
                " AND Name = " + "'" + oldCustomer.Name + "'" +
                " AND Address = " + "'" + oldCustomer.Address + "'" +
                " AND City = " + "'" + oldCustomer.City + "'" +
                " AND State = " + "'" + oldCustomer.State + "'" +
                " AND ZipCode = " + "'" + oldCustomer.ZipCode + "'";

            // Setup the command object.
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);

            // oldCustomer values are already in the database. We dont have to sanitize them (I think).
            updateCommand.Parameters.AddWithValue("@NewName", newCustomer.Name);
            updateCommand.Parameters.AddWithValue("@NewAddress", newCustomer.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", newCustomer.City);
            updateCommand.Parameters.AddWithValue("@NewState", newCustomer.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", newCustomer.ZipCode);

            // throw new NotImplementedException(updateStatement);

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
        } // end UpdateCustomer()

    } // end public static class CustomerDB
} // end namespace MMABooksDBClasses
