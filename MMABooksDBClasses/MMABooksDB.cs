/* Author:  LindyStewart
 * Changes: Eric Robinson L00709820
 * Date:    10/16/23
 * Lane Community College CS234 Advanced Programming: C# (.NET)
 * Lab 2
 * Purpose: Connect to MMABooksDB
 * Notes:   No UnitTest is required for this class for Lab 2.
 */

using System;

using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MMABooksDBClasses
{
    public static class MMABooksDB
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = GetMySqlConnectionString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
         }

        private static string GetMySqlConnectionString()
        {
            string folder = System.AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(folder)
                    .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true); // Optional??? reLoadOnChange ???

            string connectionString = builder.Build().GetConnectionString("mySql");
            return connectionString;
        }

    } // end public static class MMABooksDB
} // end namespace MMABooksDBClasses
