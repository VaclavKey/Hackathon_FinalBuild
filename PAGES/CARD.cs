using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class CARD
    {
        public static void Dispatch()
        {
            Console.Clear();

            currentBuildingID = currentCard;

            Console.WriteLine(
            " ----------------------------------- \n" +
            " |         КАРТОЧКА ОБЪЕКТА        | \n" +
            " ----------------------------------- \n" +
            "                                     \n" +
            " [1] - Вывести информацию об объекте \n" +
            " [2] - Редактировать объект          \n" +
            " [3] - Удалить объект                \n" +
            " [4] - Посмотреть задачи             \n" +
            " [0] - Выход                         \n");

            int choice = Get.IntNumber();

            switch (choice)
            {
                case 0: currentScreen = Screen.OBJECTS; break;
                case 1: Building.Print(currentBuildingID); Get.Wait(); break;
                case 2: Building.Edit(currentBuildingID); Get.Wait(); break;
                case 3: Building.Delete(currentBuildingID); Get.Wait(); break;
                case 4: currentScreen = Screen.TASKS; break;
                default: currentScreen = Screen.SEARCH; break;
            }
        }
    }
}
