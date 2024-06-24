using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class Add
    {
        public static void User()
        {
            if (currentRole == "Admin")
            {
                Console.WriteLine(" Добро пожаловать в конструктор пользователей.\n");

                int id_role;
                string? fname;
                string? sname;
                string? lname;
                string? position;
                string? login;
                string? password;

                Console.Write(" Введи ID-роли:");
                while (true)
                {
                    id_role = Get.IntNumber();
                    if (Searcher.IsThere("Role", "ID_Role", $"{id_role}")) break;

                    else Console.Write(" Такой роли не существует. Попробуй что-то ещё: ");
                }

                Console.Write(" Введи фамилию: ");
                lname = Console.ReadLine();
                Console.Write(" Введи имя: ");
                fname = Console.ReadLine();
                Console.Write(" Введи отчество: ");
                sname = Console.ReadLine();

                Console.Write(" Введи должность: ");
                position = Console.ReadLine();

                Console.Write(" Придумай логин: ");
                while (true)
                {
                    login = Console.ReadLine();
                    if (!(Searcher.IsThere("Users", "Login", $"'{login}'"))) break;
                    else Console.Write(" Этот логин уже занят. Придумай другой: ");
                }
                Console.Write(" Придумай пароль: ");
                password = Console.ReadLine();

                string sqlExpression = $"INSERT INTO Users VALUES" +
                           $"({id_role}, '{fname}', '{sname}', '{lname}', '{position}', '{login}', '{password}')";

                Executer.Execute(sqlExpression);
                Console.WriteLine(" Пользователь создан!");
                Get.Wait();
            }

            else throw (new Exception(" Отказано в доступе"));

        }

        public static void Building()
        {
            if (currentRole == "Admin")
            {

                Console.WriteLine(" Добро пожаловать в конструктор объектов.\n");

                string? cadaster;
                int id_material;
                string? address;
                int id_buildingtype;
                int square;
                int floors;

                Console.Write(" Введи кадастровый номер:");
                cadaster = Get.Cadaster();
                

                Console.Write(" Введи ID-материала:");
                while (true)
                {
                    id_material = Get.IntNumber();
                    if (Searcher.IsThere("Material", "ID_Material", $"{id_material}")) break;
                    else Console.WriteLine(" Материала с таким ID не существует. Попробуй что-нибудь другое: ");
                }

                Console.Write(" Введи адрес: ");
                address = Console.ReadLine();

                Console.Write(" Введи ID-типа здания:");
                while (true)
                {
                    id_buildingtype = Get.IntNumber();
                    if (Searcher.IsThere("BuildingType", "ID_BuildingType", $"{id_buildingtype}")) break;
                    else Console.WriteLine(" Такого ID нет в базе. Может другой?: ");
                }

                Console.Write(" Введи площадь:");
                square = Get.IntNumber();


                Console.Write(" Введи количество этажей:");
                floors = Get.IntNumber();
                

                string sqlExpression = $"INSERT INTO Building VALUES" +
                                       $"({id_material}, {id_buildingtype}, {floors}, {square}, '{cadaster}',  '{address}')";

                Executer.Execute(sqlExpression);
                Console.WriteLine(" Объект создан!");
                Get.Wait();
            }

            else Console.WriteLine(" Отказано в доступе.");
        }

        public static void Task()
        {
            if (currentRole == "Admin")
            {

                Console.WriteLine(" Добро пожаловать в конструктор задач.\n");

                int id_status;
                int id_building;
                int id_chief;
                int id_solution;
                string? date_begin;
                string? date_end;
                string? desc;

                Console.Write(" Введи ID-статуса:");
                while (true)
                {
                    id_status = Get.IntNumber();
                    if (Searcher.IsThere("Status", "ID_Status", $"{id_status}")) break;
                    else Console.Write(" Такого статуса нет в природе. Зато есть какой-то другой: ");
                };

                //Console.Write(" Введи ID-объекта:");
                //while (true)
                //{
                //    id_building = Get.IntNumber();
                //    if (Searcher.IsThere("Building", "ID_Building", $"{id_building}")) break;
                //    else Console.Write(" Объекта с таким ID ещё не построили. Давай другой: ");
                //};

                Console.Write(" Введи ID-начальника:");
                while (true)
                {
                    id_chief = Get.IntNumber();
                    if (Searcher.IsThere("Chief", "ID_Chief", $"{id_chief}")) break;
                    else Console.Write(" Начальника с таким ID не числится. Введи другой ID: ");
                };

                Console.Write(" Введи ID-решения:");
                while (true)
                {
                    id_solution = Get.IntNumber();
                    if (Searcher.IsThere("Solution", "ID_Solution", $"{id_solution}")) break;
                    else Console.Write("Не припомню решений с таким ID. Может что-то другое?: ");
                };

                Console.Write(" Введи начальную дату:");
                date_begin = Get.Date();

                Console.Write(" Введи конечную дату:");
                while (true)
                {
                    date_end = Get.Date();
                    int compare = Get.CompareDate(date_end, date_begin);

                    if (compare == 1) break;
                    else if (compare == 2) Console.Write(" Нельзя установить дату, которая раньше начальной: ");
                    else if (compare == 3) Console.Write(" Начальная и конечная даты не могут быть в один день: ");
                    else Console.Write(" Это не дата, попробуй ещё раз: ");
                }

                Console.Write(" Напиши описание: ");
                desc = Console.ReadLine();

                string sqlExpression = $"INSERT INTO Tasks VALUES" +
                                       $"({id_status}, {currentBuildingID}, {id_chief}, {id_solution}, '{date_begin}', '{date_end}', '{desc}')";

                Executer.Execute(sqlExpression);
                Console.WriteLine(" Задача создана!");
                Get.Wait();
            }

            else Console.WriteLine(" Отказано в доступе.");
        }
    }
}
