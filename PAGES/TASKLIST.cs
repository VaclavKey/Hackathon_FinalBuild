using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class TASKLIST
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.Write(
            " ------------------------------ \n" +
            " |        СПИСОК ЗАДАЧ        | \n" +
            " ------------------------------ \n" +
            "                                \n");
            Task.PrintAll(currentBuildingID);

            Console.Write(
            " [0] - Выход\n" +
            " Выбери по-индексу:");
            while (true)
            {
                int choice = Get.IntNumber();

                if (choice > 0 && choice <= currentAmountOfTasks)
                {
                    currentTaskID = CurrentTaskIDs[choice - 1];
                    currentScreen = Screen.TASK; break;
                }

                else if (choice == 0)
                {
                    currentScreen = Screen.TASKS; break;
                }
                else Console.Write(" Попробуй другой:");
            }
        }
    }
}
