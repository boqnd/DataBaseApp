using System;
using System.Data.SqlClient;
using SQLapp.Data;

namespace SQLapp
{
    public static class TestConnectingSQL
    {
        public static void TryToConnect()
        {
            Console.WriteLine();
            try
            {
                Configuration configuration = new Configuration();

                
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(configuration.builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to Start...");
            
            Console.ReadKey(true);
            Console.WriteLine("");
        }
    }
}