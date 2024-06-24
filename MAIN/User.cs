using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_final_build.Globals;

namespace hackathon_prefinal_build
{
    enum Role { Admin, Non_Admin }
    public static class User
    {
        public static void PrintAll()
        {
            int count = 0;
           
            SqlConnection connection = new(connectionSql);
            string SqlExpression = $"SELECT ID_User, fName, sName, lName FROM Users";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    CurrentUserIDs.Clear();

                    while (reader.Read())
                    {
                        count++;

                        Console.WriteLine(
                        $" [{count}]:" +
                        $" ID = {(Int32)reader.GetValue(0)} " +
                        $" Фамилия = {(string)reader.GetValue(3)} " +
                        $" Имя = {(string)reader.GetValue(1)} " +
                        $" Отчество = {(string)reader.GetValue(2)}");

                        CurrentUserIDs.Add((Int32)reader.GetValue(0));
                    }
                }
            }
        }

        public static int GetRoleID(string login)
        {
            int id_role = 0;

            SqlConnection connection = new(connectionSql);
            string sqlException1 = $"SELECT ID_Role FROM Users WHERE Login = '{login}'";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlException1, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id_role = (Int32)reader.GetValue(0);
                    }
                }
                reader.Close();

            }

            return id_role;
        }
        public static string GetRole(int id_role)
        {
            string role_name = "";

            SqlConnection connection = new(connectionSql);
            string sqlException = $"SELECT Name FROM Role WHERE ID_Role = {id_role}";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlException, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role_name = ((string)reader.GetValue(0));
                    }
                }
                reader.Close();

            }

            return role_name;
        }

        public static string GetLogin()
        {
            Console.Write(" Логин: ");

            while (true)
            {
                string? login = Console.ReadLine();
                if (Searcher.IsThere("Users", "Login", ($"'{login}'")))
                {
                    return login;
                }
                else Console.Write(" Такого логина нет в базе. Вводи другой: ");
            }
        }

        public static bool ComparePassword(string login, string password)
        {
            SqlConnection connection = new(connectionSql);
            string sqlExpression = $"SELECT login, password FROM Users WHERE Login = '{login}' and Password = '{password}'";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) return true;

                else return false;
            }
        }


        public static string Authorization()
        {
            string? login = GetLogin();

            Console.Write(" Пароль: ");
            while (true)
            {
                string? password = Console.ReadLine();
                if (ComparePassword(login, password)) break;
                else Console.Write(" Неверный пароль. Попробуй ещё раз: ");
            }

            currentUserID = GetID(login);

            return GetRole(GetRoleID(login));
        }


        public static int GetAmount()
        {
            int count = 0;

            SqlConnection connection = new(connectionSql);
            string sqlException = $"SELECT * FROM Users";


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
                reader.Close();
            }

            return count;
        }

        public static int Chose()
        {
            int ID = 0;

            PrintAll();

            Console.Write(
            " [0] - Вызод\n" +
            " Выбери по-индексу:");
            while (true)
            {
                int choice = Get.IntNumber();

                if (choice > 0 && choice <= GetAmount())
                {
                    ID = CurrentUserIDs[choice - 1];
                    break;
                }

                else if (choice == 0) break;

                else Console.Write(" Попробуй другое:");
            }

            return ID;
        }
        public static void Delete()
        {
            if (currentRole == "Admin")
            {
                if (GetAmount() <= 1) throw new Exception(" Ты не можешь удалить последнего пользователя.");

                else
                {
                    int ID = Chose();

                    if (Searcher.IsThere("Chief", "ID_User", $"{ID}"))
                    {
                        Console.WriteLine(" Ты не можешь удалять аккаунты начальников.");
                        Get.Wait();
                    }

                    else
                    {
                        if (ID != 0)
                        {
                            Console.Write($" Ты уверен, что хочешь удалить аккаунт?\n [Y/n]: ");
                            string? choice = Console.ReadLine();
                            
                            if (choice == "Y" || choice == "y")
                            {
                                string sqlExpression = $"DELETE FROM Users WHERE ID_User = {ID}";
                                Executer.Execute(sqlExpression);

                                Console.WriteLine(" Пользователь удалён!");
                                

                                if (ID == currentUserID) currentScreen = Screen.SIGN_IN;
                            }

                            else
                            {
                                Console.WriteLine(" ОК, назад");
                            }
                        }
                    }
                }
            }

            else throw new Exception(" Отказано в доступе.");
        }

        public static int GetID(string login)
        {
            int ID = 0;

            SqlConnection connection = new(connectionSql);
            string sqlExpression = $"SELECT ID_User FROM Users WHERE Login = '{login}'";


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (Int32)reader.GetValue(0);
                    }
                }
                reader.Close();
            }

            return ID;
        }
    }
}
