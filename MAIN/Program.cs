using static hackathon_prefinal_build.Globals;
using System.Data;

namespace hackathon_prefinal_build
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                switch (currentScreen)
                {
                    // Окно авторизации
                    case Screen.SIGN_IN: SIGN_IN.Dispatch(); break;

                    // Главное меню
                    case Screen.MAIN: MAIN.Dispatch(); break;

                    // Страница объектов
                    case Screen.OBJECTS: OBJECTS.Dispatch(); break;

                    // Страница статистики

                    case Screen.STATS: STATS.Dispatch(); break;

                    // Окно поиска по атрибуту
                    case Screen.SEARCH: SEARCH.Dispatch(); break;

                    // Меню пользователей
                    case Screen.USERS: USERS.Dispatch(); break;

                    // Карточка объекта
                    case Screen.CARD: CARD.Dispatch(); break;

                    // Страница задач
                    case Screen.TASKS: TASKS.Dispatch(); break;

                    // Список задач
                    case Screen.TASKLIST: TASKLIST.Dispatch(); break;

                    // Страница задачи
                    case Screen.TASK: TASKCARD.Dispatch(); break;

                    // Выход
                    default: System.Environment.Exit(1); break;
                }
            }
        }
    }
}


