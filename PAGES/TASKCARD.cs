using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class TASKCARD
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " --------------------------------- \n" +
            " |        СТРАНИЦА ЗАДАЧИ        | \n" +
            " --------------------------------- \n" +
            "                                   \n" +
            " [1] - Вывести информацию о задаче \n" +
            " [2] - Редактировать задачу        \n" +
            " [3] - Удалить задачу              \n" +
            " [0] - Выход                       \n");

            Int32.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 0: currentScreen = Screen.TASKLIST; break;
                case 1: Task.Print(currentTaskID); Get.Wait(); break;
                case 2: Task.Edit(currentTaskID); Get.Wait(); break;
                case 3: Task.Delete(currentTaskID); Get.Wait(); break;
                default: Console.Write("Попробуй другое:"); break;
            }
        }

    }
}
