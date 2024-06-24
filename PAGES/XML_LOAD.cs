using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hackathon_prefinal_build.Globals;
using static System.Formats.Asn1.AsnWriter;

namespace hackathon_prefinal_build
{
    internal class XML_LOAD
    {
        public static void Dispatch()
        {
            Console.Write(
            " ------------------- \n " +
            " | ЗАГРУЗКА ИЗ XML | \n " +
            " ------------------- \n " +
            "                     \n" +
            " Введите название XML-файла: ");

            while (true)
            {
                string? filename = Console.ReadLine();
                List<char> ls = [.. filename];

                int len = filename.Length;
                if (len > 4)
                {

                    //if (ls[len - 1] == 'l' && ls[len - 2] == 'm' && ls[len - 3] == 'x' && ls[len - 4] == '.')
                    //{
                    //    XML_loader.LoadQuery(filename);
                    //    break;
                    //}

                    if (filename.Remove(0, len - 4) == ".xml")
                    {
                        string path = directory + filename;
                        if (File.Exists(path))
                        {
                            XML_loader.LoadQuery(filename);
                            break;
                        }
                        else Console.Write(" Такого файла не существует. Попробуй другой: ");
                    }
                }
                else Console.Write(" Это не похоже на XML-файл. Попробуй ещё раз: ");
            }
        }
    }
}
