using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Framework.Helpers
{
    public class SqlDatabaseConncetionHelper
    {
        public static int ExecuteSqlCommand(string queryToExecute, string connectionString)
        {
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            SqlCommand command = new SqlCommand(queryToExecute, databaseConnection);
            int result = command.ExecuteNonQuery();
            databaseConnection.Close();
            return result;
        }

        public static void ExecuteDeleteSqlCommand(string queryToExecute, string connectionString)
        {
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.Open();
            SqlCommand command = new SqlCommand(queryToExecute, databaseConnection);
            adapter.DeleteCommand = new SqlCommand(queryToExecute, databaseConnection);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            databaseConnection.Close();
        }

        public static List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(connectionString))
                {
                    databaseConnection.Open();
                    SqlCommand command = new SqlCommand(queryToExecute, databaseConnection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    List<object[]> result = new List<object[]>();
                    while (dataReader.Read())
                    {
                        object[] items = new object[100];
                        dataReader.GetValues(items);
                        result.Add(items);
                    }
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Exception occurred while executing SQL query"
                    + "\n Exception: " + exception);
            }
        }
    }
}