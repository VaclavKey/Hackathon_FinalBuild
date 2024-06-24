using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class Building
    {
        public static void PrintAll()
        {
            int count = 0;

            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT ID_Building, Cadaster, Address FROM Building";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    CurrentBuildingIDs.Clear();

                    while (reader.Read())
                    {
                        count++;

                        Console.WriteLine(
                        $" [{count}]:" +
                        $" ID = {(Int32)reader.GetValue(0)} " +
                        $" Кадастровый номер = {(string)reader.GetValue(1)} " +
                        $" Адрес = {(string)reader.GetValue(2)} " +
                        $" Задачи = {Count.Tasks((Int32)reader.GetValue(0))}");


                        CurrentBuildingIDs.Add((Int32)reader.GetValue(0));
                    }
                }
            }
        }



        public static void Print(int ID)
        {
            Console.Clear();
            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT * FROM Building WHERE ID_Building = {ID}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    CurrentBuildingIDs.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine
                        ($" [1] - ID-здания = {(Int32)reader.GetValue(0)}\n" +
                         $" [2] - Материал = {Get.SelectString("Material", "Material", "ID_Material", $"{(Int32)reader.GetValue(1)}")}\n" +
                         $" [3] - Типа здания = {Get.SelectString("BuildingType", "Name", "ID_BuildingType", $"{(Int32)reader.GetValue(2)}")}\n" +
                         $" [4] - Кол-во этажей = {(Int32)reader.GetValue(3)}\n" +
                         $" [5] - Площадь = {(double)reader.GetValue(4)}\n" +
                         $" [6] - Кадастровый номер = {(string)reader.GetValue(5)}\n" +
                         $" [7] - Адрес = {(string)reader.GetValue(6)}\n");


                        CurrentBuildingIDs.Add((Int32)reader.GetValue(0));
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
                Console.WriteLine(" Выбери столбец:");
                while (true)
                {
                    column = Get.IntNumber();
                    if (column > 1 && column < 8) break;
                    else Console.Write(" Попробуй другой: ");
                }

                string columnName = GetColumn(column);
                if (column > 1 && column < 4) tableName = GetTable(column);

                Console.Write(" Придумай новое значение:");
                if (column > 1 && column < 4)
                {
                    while (true)
                    {
                        int value = Get.IntNumber();
                        if (Searcher.IsThere(tableName, columnName, value.ToString()))
                        {
                            string sqlExpression = $"UPDATE Building SET {columnName} = {value} WHERE ID_Building = {ID}";
                            Executer.Execute(sqlExpression);
                            break;
                        }
                        else Console.Write($" Такого {columnName} не существует. Попробуй другой:");
                    }
                }

                else if (column == 4)
                {
                    int value = Get.IntNumber();
                    string sqlExpression = $"UPDATE Building SET {columnName} = {value} WHERE ID_Building = {ID}";
                    Executer.Execute(sqlExpression);
                }

                else if (column == 5)
                {
                    double value = Get.DoubleNumber();
                    string sqlExpression = $"UPDATE Building SET {columnName} = {value} WHERE ID_Building = {ID}";
                    Executer.Execute(sqlExpression);
                }

                else if (column > 5)
                {
                    Console.Write(" ");
                    string? value = Console.ReadLine();
                    string sqlExpression = $"UPDATE Building SET {columnName} = '{value}' WHERE ID_Building = {ID}";
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
                Console.WriteLine($" Ты уверен, что хочешь удалить объект?\n[Y/n]: ");
                string? choice = Console.ReadLine();

                if (choice == "Y" || choice == "y")
                {

                    string sqlExpression = $"DELETE FROM Tasks WHERE ID_Building = {ID};" +
                                           $"DELETE FROM Building WHERE ID_Building = {ID}";
                    Executer.Execute(sqlExpression);

                    Console.WriteLine(" Объект был удалён");
                    currentScreen = Screen.OBJECTS;
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
                1 => "ID_Building",
                2 => "ID_Material",
                3 => "ID_BuildingType",
                4 => "Floors",
                5 => "Square",
                6 => "Cadaster",
                7 => "Address",
                _ => "0",
            };
        }

        public static string GetTable(int column)
        {
            return column switch
            {
                2 => "Material",
                3 => "BuildingType",
                _ => "0",
            };
        }


        public static void Chose()
        {
            PrintAll();

            Console.Write(
            " [0] - Выход\n" +
            " Выбери по-индексу:");
            while (true)
            {
                int choice = Get.IntNumber();

                if (choice > 0 && choice <= Count.Buildings())
                {
                    currentCard = CurrentBuildingIDs[choice - 1];
                    currentScreen = Screen.CARD;
                    break;
                }

                else if (choice == 0) break;

                else Console.Write(" Попробуй другое:");
            }
        }

        public static void Counter()
        {
            Console.Clear();

            Console.WriteLine(
            $" ------------------ \n" +
            $" | СЧЁТЧИК ЗДАНИЙ | \n" +
            $" ------------------ \n" +
            $"                    \n" +
            $" На данный момент в системе числится:\n [{Count.Buildings()}] объектов\n");
        }
    }
}
