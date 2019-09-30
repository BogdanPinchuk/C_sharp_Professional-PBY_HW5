using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Інформація про файл
            using (FileStream stream = new FileStream(@"Resources\TelephoneBook.xml", FileMode.Open))
            {
                // загрузка файла
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);

                // корневий елемент документа
                XmlNode root = xmlDoc.DocumentElement;

                Console.WriteLine("Номера телефонів:");

                foreach (XmlNode elem in root.ChildNodes)
                {
                    Console.WriteLine($"\t{elem.InnerText}");
                }
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
