using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static hackathon_prefinal_build.Globals;


namespace hackathon_prefinal_build
{
    public class Get
    {
        public static string SelectString(string table, string selectcolumn, string wherecolumn, string value)
        {
            SqlConnection connection = new SqlConnection(connectionSql);
            string sqlExpression = $"SELECT {selectcolumn} FROM {table} WHERE {wherecolumn} = '{value}'";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (string)reader.GetValue(0);
                    }
                } 
            }
            return "0";
        }

        public static string SelectString(int num, string table, string selectcolumn, string wherecolumn, string value)
        {
            SqlConnection connection = new SqlConnection(connectionSql);
            string sqlExpression = $"SELECT {selectcolumn} FROM {table} WHERE {wherecolumn} = '{value}'";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                string select = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < num; i++)
                        {
                            select += (string)reader.GetValue(i);
                            select += " ";
                        }
                    }
                    return select;
                }
            }
            return "0";
        }

        public static int SelectInt(string table, string selectcolumn, string wherecolumn, int value)
        {
            SqlConnection connection = new SqlConnection(connectionSql);
            string sqlExpression = $"SELECT {selectcolumn} FROM {table} WHERE {wherecolumn} = {value}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (Int32)reader.GetValue(0);
                    }
                }
            }
            return 0;
        }


        public static void Wait()
        {
            Console.Write(" ");
            Console.ReadKey();
        }

        public static int IntNumber()
        {
            while (true)
            {
                Console.Write(" ");
                string? input = Console.ReadLine();
                if (Int32.TryParse(input, out int number)) return number;
                else Console.Write(" Это не похоже на число. Попробуй ещё раз:");
            }
        }

        public static double DoubleNumber()
        {
            while (true)
            {
                Console.Write(" ");
                string? input = Console.ReadLine();
                if (Double.TryParse(input, out double number)) return number;
                else Console.Write(" Это не похоже на число. Попробуй ещё раз:");
            }
        }

        public static bool IsDate(string date)
        {
            if (date.Length == 10)
            {
                int nums = 0;
                int dots = 0;

                if (date.Length == 10)
                {
                    List<char> letters = [.. date];
                    List<int> numbers = [];

                    foreach (char c in letters)
                    {
                        if (Int32.TryParse((c.ToString()), out int number))
                        {
                            nums++;
                            numbers.Add(number);
                        }
                        else if (c == '.') dots++;
                    }

                    if (nums == 8 && dots == 2 && letters[2] == '.' && letters[5] == '.')
                    {
                        bool valid_day = false;
                        bool valid_month = false;

                        switch (numbers[0])
                        {
                            case 0: if (numbers[1] <= 9) valid_day = true; break;
                            case 1: if (numbers[1] <= 9) valid_day = true; break;
                            case 2: if (numbers[1] <= 9) valid_day = true; break;
                            case 3: if (numbers[1] == 30) valid_day = true; break;
                            default: valid_day = false; break;
                        }

                        switch (numbers[2])
                        {
                            case 0: if (numbers[3] <= 9) valid_month = true; break;
                            case 1: if (numbers[3] <= 2) valid_month = true; break;
                            default: valid_month = false; break;
                        }

                        if (valid_day && valid_month) return true;
                    }
                }
            }

            return false;
        }


        public static int CompareDate(string date1, string date2)
        {
            if (IsDate(date1) && IsDate(date2))
            {
                List<int> numbers1 = [];
                List<int> numbers2 = [];

                foreach (char c in date1) if (Int32.TryParse(c.ToString(), out int number)) numbers1.Add(number);
                foreach (char c in date2) if (Int32.TryParse(c.ToString(), out int number)) numbers2.Add(number);



                _ = int.TryParse((numbers1[4].ToString() + numbers1[5].ToString() + numbers1[6].ToString() + numbers1[7].ToString()), out int year1);
                _ = int.TryParse((numbers2[4].ToString() + numbers2[5].ToString() + numbers2[6].ToString() + numbers2[7].ToString()), out int year2);

                _ = int.TryParse((numbers1[2].ToString() + numbers1[3].ToString()), out int month1);
                _ = int.TryParse((numbers2[2].ToString() + numbers2[3].ToString()), out int month2);

                _ = int.TryParse((numbers1[0].ToString() + numbers1[1].ToString()), out int day1);
                _ = int.TryParse((numbers2[0].ToString() + numbers2[1].ToString()), out int day2);


                int year_status = 0;
                int month_status = 0;
                int day_status = 0;


                if (year1 == year2) year_status = 3;
                else if (year1 > year2) year_status = 1;
                else if (year1 < year2) year_status = 2;

                if (month1 == month2) month_status = 3;
                else if (month1 > month2) month_status = 1;
                else if (month1 < month2) month_status = 2;

                if (day1 == day2) day_status = 3;
                else if (day1 > day2) day_status = 1;
                else if (day1 < day2) day_status = 2;


                if (year_status < 3) return year_status;
                else
                {
                    if (month_status < 3) return month_status;
                    else
                    {
                        if (day_status < 3) return day_status;
                        else return 3;
                    }
                }
            }

            else return 0;
        }



        public static string Date()
        {
            while (true)
            {
                int nums = 0;
                int dots = 0;

                Console.Write(" ");
                string? input = Console.ReadLine();
                if (input.Length == 10)
                {
                    List<char> letters = [.. input];
                    List<int> numbers = [];

                    foreach (char c in letters)
                    {
                        if (Int32.TryParse((c.ToString()), out int number))
                        {
                            nums++;
                            numbers.Add(number);
                        }
                        else if (c == '.') dots++;
                    }

                    if (nums == 8 && dots == 2 && letters[2] == '.' && letters[5] == '.')
                    {
                        bool valid_day = false;
                        bool valid_month = false;

                        switch (numbers[0])
                        {
                            case 0: if (numbers[1] <= 9) valid_day = true; break;
                            case 1: if (numbers[1] <= 9) valid_day = true; break;
                            case 2: if (numbers[1] <= 9) valid_day = true; break;
                            case 3: if (numbers[1] == 30) valid_day = true; break;
                            default: valid_day = false; break;
                        }
                        switch (numbers[2])
                        {
                            case 0: if (numbers[3] <= 9) valid_month = true; break;
                            case 1: if (numbers[3] <= 2) valid_month = true; break;
                            default: valid_month = false; break;
                        }

                        if (valid_day && valid_month) return input;
                    }
                }
                Console.Write(" Неверный формат. Попробуй так: [ дд.мм.гггг ]:");
            }
        }

        public static string Cadaster()
        {
            while (true)
            {
                int nums = 0;
                int dots = 0;

                Console.Write(" ");
                string? input = Console.ReadLine();
                if (input.Length == 15)
                {
                    List<char> letters = [.. input];
                    List<int> numbers = [];

                    foreach (char c in letters)
                    {
                        if (Int32.TryParse(c.ToString(), out int number))
                        {
                            nums++;
                            numbers.Add(number);
                        }
                        else if (c == ':') dots++;
                    }

                    if (nums == 12 && dots == 3 && letters[2] == ':' && letters[5] == ':' && letters[12] == ':')
                    {
                        if (Searcher.IsThere("Building", "Cadaster", $"'{input}'")) Console.Write(" Этот номер уже занят. Попробуй другой:");
                        else return input;
                    }

                    else Console.Write(" Неверный формат.\n Попробуй ввести номер в следующем формате: [ xx:xx:xxxxxx:xx ]:");
                }

                else Console.Write(" Неверный формат.\n Попробуй ввести номер в следующем формате: [ xx:xx:xxxxxx:xx ]:");
            }
        }
    }
}
