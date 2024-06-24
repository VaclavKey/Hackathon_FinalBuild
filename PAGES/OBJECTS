using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_final_build.Globals;

namespace hackathon_prefinal_build
{
    internal class OBJECTS
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " ----------------------- \n" +
            " |       ОБЪЕКТЫ       | \n" +
            " ----------------------- \n" +
            "                         \n" +
            " [1] - Добавить объект   \n" +
            " [2] - Выбрать из списка \n" +
            " [3] - Поиск по фильтру  \n" +
            " [4] - Статистика        \n" +
            " [5] - Добавить объект из XML-файла \n" +
            " [0] - Выход             \n");

            while (true)
            {
                int choise = Get.IntNumber();

                switch (choise)
                {
                    case 0: currentScreen = Screen.MAIN; break;
                    case 1: Add.Building(); break;
                    case 2: Building.Chose(); break;
                    case 3: currentScreen = Screen.SEARCH; break;
                    case 4: currentScreen = Screen.STATS; break;
                    case 5: XML_LOAD.Dispatch(); break;
                    default: Console.Write("Попробуй другое:"); break;
                }
                break;
            }
        }
    }
}
