using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;


namespace hackathon_prefinal_build
{
    public class Searcher
    {
        public static bool IsThere(string par1, string par2, string par3)
        {
            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT * FROM {par1} WHERE {par2} = {par3}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) return true;

                return false;
            }
        }
        public static void SearchBy(string par1, string par2)
        {
            isSearched = false;

            int count = 0;

            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT ID_Building, Cadaster FROM Building WHERE {par1} = {par2}";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isSearched = true;
                    CurrentBuildingIDs.Clear();

                    while (reader.Read())
                    {
                        count++;

                        Console.WriteLine(
                        $" [{count}]:" +
                        $" ID = {(Int32)reader.GetValue(0)}  " +
                        $" Cadaster = {(string)reader.GetValue(1)}");

                        CurrentBuildingIDs.Add((Int32)reader.GetValue(0));
                    }
                    currentRows = count;
                }
                reader.Close();
            }
        }

        public static void SearchBy(string par1, string par2, string par3)
        {
            isSearched = false;

            int count = 0;

            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT ID_Building, Cadaster FROM Building WHERE {par1} >= {par2} and {par1} <= {par3}";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isSearched = true;
                    CurrentBuildingIDs.Clear();

                    while (reader.Read())
                    {
                        count++;

                        Console.WriteLine(
                        $" [{count}]:" +
                        $" ID = {(Int32)reader.GetValue(0)}  " +
                        $" Cadaster = {(string)reader.GetValue(1)}");

                        CurrentBuildingIDs.Add((Int32)reader.GetValue(0));
                    }
                    currentRows = count;
                }
                reader.Close();
            }
        }
    }
}
