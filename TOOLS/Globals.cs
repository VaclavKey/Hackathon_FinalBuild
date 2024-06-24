using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackathon_prefinal_build
{
    public class Globals
    {
        public enum Screen { SIGN_IN, MAIN, OBJECTS, STATS, SEARCH, CARD, TASKLIST, TASK, TASKS, USERS };
        public static Screen currentScreen = Screen.SIGN_IN;

        public static string directory = @"" // Здесь нужно указать директорию, откуда брать XML-файлы;
        public static string connectionSql = @"" // Здесь нужно указать строку подключения к базе данных;
        public static string currentRole = "Admin";

        public static List<int> CurrentBuildingIDs = [];
        public static List<int> CurrentTaskIDs = [];
        public static List<int> CurrentUserIDs = [];

        public static int currentAmountOfUsers = User.GetAmount();
        public static int currentAmountOfTasks = 0;
        public static int currentBuildingID = 0;
        public static int currentTaskID = 0;
        public static int currentUserID = 0;
        public static int currentRows = 0;
        public static int currentCard = 0;

        public static bool isSearched = false;
    }
}
