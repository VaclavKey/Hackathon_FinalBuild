using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    internal class TASKS
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " ------------------------ \n" +
            " |        ЗАДАЧИ        | \n" +
            " ------------------------ \n" +
            "                          \n" +
            " [1] - Добавить задачу    \n" +
            " [2] - Перейти к задачам  \n" +
            " [0] - Выход              \n");

            while (true)
            {
                int choice = Get.IntNumber();

                switch (choice)
                {
                    case 0: currentScreen = Screen.CARD; break;
                    case 1: Add.Task(); break;
                    case 2: currentScreen = Screen.TASKLIST; break;
                    default: Console.Write(" Попробуй другое:"); break;
                }
                break;
            }
        }
    }
}
