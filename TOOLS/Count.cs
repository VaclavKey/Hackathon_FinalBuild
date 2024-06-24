using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static hackathon_prefinal_build.Globals;


namespace hackathon_prefinal_build
{
    internal class Count
    {
        public static int Buildings()
        {
            int count = 0;

            SqlConnection connection = new(connectionSql);
            string sqlException = $"SELECT * FROM Building";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlException, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int Tasks()
        {
            int count = 0;

            SqlConnection connection = new(connectionSql);
            string sqlException = $"SELECT * FROM Tasks";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlException, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int Tasks(int ID)
        {
            int count = 0;

            SqlConnection connection = new(connectionSql);
            string sqlException = $"SELECT * FROM Tasks WHERE ID_Building = {ID}";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlException, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
