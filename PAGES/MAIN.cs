using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_final_build
{
    public class MAIN
    {
        public static void Dispatch()
        {
            Console.Clear();

            XML_loader.LoadQuery("Xml_qer.xml");

            Console.WriteLine(
            " -------------------------- \n" +
            " |      ГЛАВНОЕ МЕНЮ      | \n" +
            " -------------------------- \n" +
            "                            \n" +
            " [1] - Объекты              \n" +
            " [2] - Пользователи         \n" +
            " [3] - Сменить пользователя \n" +
            " [0] - Выход                \n");

            while (true)
            {
                int choice = Get.IntNumber();

                switch (choice)
                {
                    case 0: System.Environment.Exit(1); break;
                    case 1: currentScreen = Screen.OBJECTS; break;
                    case 2: currentScreen = Screen.USERS; break;
                    case 3: currentScreen = Screen.SIGN_IN; break;
                    default: Console.Write(" Попробуй ещё раз:"); break;
                }
                break;
            }
        }
    }
}
