using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_final_build
{
    internal class STATS
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " -------------------- \n" +
            " |    СТАТИСТИКА    | \n" +
            " -------------------- \n" +
            "                      \n" +
            " [1] - Счётчик зданий \n" +
            " [2] - Счётчик задач  \n" +
            " [0] - Выход          \n");

            while (true)
            {
                int choice = Get.IntNumber();

                switch (choice)
                {
                    case 0: currentScreen = Screen.OBJECTS; break;
                    case 1: Building.Counter(); Get.Wait(); break;
                    case 2: Task.Counter(); Get.Wait(); break;
                    default: Console.Write("Попробуй другое:"); break;
                }
                break;
            }
        }
    }
}
