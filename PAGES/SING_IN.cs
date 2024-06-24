using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;

namespace hackathon_prefinal_build
{
    internal class SIGN_IN
    {
        public static void Dispatch()
        {
            Console.Clear();

            Console.WriteLine(
            " --------------- \n" +
            " | Авторизация | \n" +
            " --------------- \n");

            string? role = User.Authorization();
            currentRole = role;

            currentScreen = Screen.MAIN;
        }
    }
}
