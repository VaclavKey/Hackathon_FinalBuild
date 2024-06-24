using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hackathon_prefinal_build
{
    public class XML_loader
    {
        public static string MakeQuery(string file)
        {
            XDocument xDoc = XDocument.Load(file);
            XElement? buildings = xDoc.Element("buildings");

            if (buildings is not null)
            {
                string SqlExpression = "";

                foreach (XElement building in buildings.Elements("building"))
                {
                    XElement? cadaster = building.Element("cadaster");
                    XElement? id_material = building.Element("id_material");
                    XElement? address = building.Element("address");
                    XElement? id_buildingtype = building.Element("id_buildingtype");
                    XElement? square = building.Element("square");
                    XElement? floors = building.Element("floors");

                    Console.WriteLine(
                    $" Кадастровый номер: {cadaster?.Value}\n" +
                    $" ID-Материал: {id_material?.Value}\n" +
                    $" Адрес: {address?.Value}\n" +
                    $" ID-типа здания: {id_buildingtype?.Value}\n" +
                    $" Площадь: {square?.Value}\n" +
                    $" Кол-во этажей: {floors?.Value}\n");

                    Console.WriteLine();

                    SqlExpression += $"INSERT INTO Building VALUES" +
                                     $"({id_material?.Value}, {id_buildingtype?.Value}, {floors?.Value}, {square?.Value}, '{cadaster?.Value}',  '{address?.Value}')";
                }

                return SqlExpression;
            }

            return "";
        }

        public static void LoadQuery(string file)
        {
            SqlConnection connection = new(Globals.connectionSql);
            string SqlXmlException = MakeQuery(file);


            using (connection)
            {
                connection.Open();

                SqlCommand command = new(SqlXmlException, connection);
                command.ExecuteNonQuery();

                Console.WriteLine(" Таблица обновлена");
            }
            Get.Wait();
        }

    }
}
