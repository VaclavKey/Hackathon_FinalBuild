using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_final_build.Globals;

namespace hackathon_prefinal_build
{
    public class Executer
    {
        static public void Execute(string ex)
        {
            SqlConnection connection = new(connectionSql);
            string SqlExpression = ex;

            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                command.ExecuteNonQuery();

                Console.WriteLine(" Запрос выполнен");
            }
        }
    }
}
