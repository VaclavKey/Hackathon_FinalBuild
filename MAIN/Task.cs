using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class Task
    {
        public static void PrintAll(int ID)
        {
            Console.Clear();
            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT ID_Task, Description FROM Tasks WHERE ID_Building = {ID}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                int count = 0;

                if (reader.HasRows)
                {
                    CurrentTaskIDs.Clear();

                    while (reader.Read())
                    {
                        count++;

                        Console.WriteLine(
                        $" [{count}]:" +
                        $" ID_Task = {(Int32)reader.GetValue(0)}   " +
                        $" Description = {(string)reader.GetValue(1)}\n");

                        CurrentTaskIDs.Add((Int32)reader.GetValue(0));
                    }
                    currentAmountOfTasks = count;
                }

            }
        }

        public static void Print(int ID)
        {
            Console.Clear();
            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT * FROM Tasks WHERE ID_Task = {ID}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Console.WriteLine(
                        $" [1] - ID-Задачи = {(Int32)reader.GetValue(0)}\n" +
                        $" [2] - Статус = {Get.SelectString("Status", "Name", "ID_Status", $"{(Int32)reader.GetValue(1)}")}\n" +
                        $" [3] - ID-Здания = {(Int32)reader.GetValue(2)}\n" +
                        $" [4] - Начальник = {Get.SelectString(3, "Users", "fName, sName, lName", "ID_User", $"{Get.SelectInt("Chief", "ID_User", "ID_Chief", (Int32)reader.GetValue(3))}")}\n" +
                        $" [5] - Решениe = {Get.SelectString("Solution", "Description", "ID_Solution", $"{(Int32)reader.GetValue(4)}")}\n" +
                        $" [6] - Дата начала = {(string)reader.GetValue(5)}\n" +
                        $" [7] - Дата окончания = {(string)reader.GetValue(6)}\n" +
                        $" [8] - Описание = {(string)reader.GetValue(7)}\n");

                        CurrentTaskIDs.Add((Int32)reader.GetValue(0));
                    }
                }
                reader.Close();
            }
        }

        public static void Edit(int ID)
        {
            if (currentRole == "Admin")
            {
                int column;
                string tableName = "";

                Print(ID);
                Console.Write(" Выбери столбец: ");
                while (true)
                {
                    column = Get.IntNumber();
                    if (column > 1 && column < 9) break;
                    else Console.Write(" Попробуй другую: ");
                }

                string columnName = GetColumn(column);
                if (column > 1 && column < 6) tableName = GetTable(column);

                Console.Write(" Придумай новое значение: ");
                if (column > 1 && column < 6)
                {
                    while (true)
                    {
                        int value = Get.IntNumber();
                        if (Searcher.IsThere(tableName, columnName, value.ToString()))
                        {
                            string sqlExpression = $"UPDATE Tasks SET {columnName} = {value} WHERE ID_Task = {ID}";
                            Executer.Execute(sqlExpression);
                            break;
                        }
                        else Console.Write($" Такого {columnName} не существует. Давай ещё раз: ");
                    }
                }

                else if (column > 5 && column < 8)
                {
                    string? value = Get.Date();                   
                    string sqlExpression = $"UPDATE Tasks SET {columnName} = '{value}' WHERE ID_Task = {ID}";
                    Executer.Execute(sqlExpression);
                }

                else if (column == 8)
                {
                    string? value = Console.ReadLine();
                    string sqlExpression = $"UPDATE Tasks SET {columnName} = '{value}' WHERE ID_Task = {ID}";
                    Executer.Execute(sqlExpression);
                }
            }

            else Console.WriteLine(" Отказано в доступе.");
        }

        public static void Delete(int ID)
        {
            Console.Clear();
            if (currentRole == "Admin")
            {
                Console.WriteLine($" Ты уверен, что хочешь удалить задачу?\n [Y/n]: ");
                string? choice = Console.ReadLine();

                if (choice == "Y" || choice == "y")
                {
                    string sqlExpression = $"DELETE FROM Tasks WHERE ID_Task = {ID}";

                    Executer.Execute(sqlExpression);

                    Console.WriteLine(" Задача удалена!");
                    currentScreen = Screen.TASKLIST;
                }

                else
                {
                    Console.WriteLine(" ОК, назад");
                }
            }

            else Console.WriteLine(" Отказано в доступе.");
        }


        public static string GetColumn(int column)
        {
            return column switch
            {
                0 => "0",
                1 => "ID_Task",
                2 => "ID_Status",
                3 => "ID_Building",
                4 => "ID_Chief",
                5 => "ID_Solution",
                6 => "DateBegin",
                7 => "DateEnd",
                8 => "Description",
                _ => "0",
            };
        }

        public static string GetTable(int column)
        {
            return column switch
            {
                2 => "Status",
                3 => "Building",
                4 => "Chief",
                5 => "Solution",
                _ => "0",
            };
        }
    
    
        public static void Counter()
        {
            Console.Clear();

            Console.WriteLine(
            " ----------------- \n" +
            " | СЧЁТЧИК ЗАДАЧ | \n" +
            " ----------------- \n" +
            "                   \n" +
            $" На данный момент суммарное количество задач равняется:\n [{Count.Tasks()}]\n");
        }
    }
}
