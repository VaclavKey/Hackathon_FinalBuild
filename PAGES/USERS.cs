using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    internal class USERS
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " -------------------------- \n" +
            " |   МЕНЮ ПОЛЬЗОВАТЕЛЕЙ   | \n" +
            " -------------------------- \n" +
            "                            \n" +
            " [1] - Создать пользователя \n" +
            " [2] - Удалить пользователя \n" +
            " [3] - Список пользователей \n" +
            " [0] - Выход                \n");

            int choice = Get.IntNumber();

            switch(choice )
            {
                case 0: currentScreen = Screen.MAIN; break;
                case 1: Add.User(); break;
                case 2: User.Delete(); Get.Wait();
                    break;
                case 3: User.PrintAll(); Get.Wait(); break;
                default: Console.Write(" Попробуй другое:"); break;
            }
        }
    }
}
