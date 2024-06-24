using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    public class SEARCH
    {
        public static void Dispatch()
        {
            Console.Clear();

            isSearched = false;
            Console.WriteLine(
            " ------------------- \n" +
            " |   МЕНЮ ПОИСКА   | \n" +
            " ------------------- \n" +
            "                     \n" +
            " Выбери атрибут:     \n" +
            " [1] - Тип здания    \n" +
            " [2] - Площадь       \n" +
            " [3] - Кол-во этажей \n" +
            " [0] - Выход         \n");

            int attribute;

            while (true)
            {
                attribute = Get.IntNumber();

                switch (attribute)
                {
                    case 0:
                        currentScreen = Screen.OBJECTS;
                        break;

                    case 1:
                        {
                            Console.Write(" Введи ID-типа здания:");
                            while (true)
                            {
                                int buildingTypeID = Get.IntNumber();

                                if (Searcher.IsThere("BuildingType", "ID_BuildingType", buildingTypeID.ToString()))
                                {
                                    Searcher.SearchBy("ID_BuildingType", buildingTypeID.ToString()); break;
                                }
                                else Console.Write($" Такого типа не существует. Давай по-новой: ");
                            }
                        }
                    break;

                    case 2:
                        {
                            Console.Write(" Введи интервал площади");

                            Console.Write(" Введи нижний интервал:");
                            double square1 = Get.DoubleNumber();
                            Console.Write(" Введи верхний интервал:");
                            double square2 = Get.DoubleNumber();

                            Searcher.SearchBy("Square", square1.ToString(), square2.ToString());
                        }
                        break;

                    case 3:
                        {
                            Console.Write(" Введи интервал количества этажей");

                            Console.Write(" Введи нижний интервал:");
                            int floors1 = Get.IntNumber();
                            Console.Write(" Введи верхний интервал:");
                            int floors2 = Get.IntNumber();

                            Searcher.SearchBy("Floors", floors1.ToString(), floors2.ToString());
                        }
                        break;

                    default: Console.Write(" Попробуй другое:"); break;
                }
                break;
            }

            if (isSearched)
            {
                Console.Write(" Выбери по-индексу:");
                while (true)
                {
                    int choice = Get.IntNumber();

                    if (choice > 0 && choice <= currentRows)
                    {
                        currentCard = CurrentBuildingIDs[choice - 1];
                        break;
                    }

                    else Console.Write(" Попробуй другой:");
                }
                
                if (attribute > 0 && attribute < 4) currentScreen = Screen.CARD;
            }
        }
    }
}
