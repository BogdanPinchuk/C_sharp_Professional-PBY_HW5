using LesApp1.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LesApp1
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
#if true
                // загрузка файла
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);

                // корневий елемент документа
                XmlNode root = xmlDoc.DocumentElement;

                // базовий вузол
                Console.WriteLine("ParentNode:");
                Console.WriteLine($"\tLocalName: {root.ParentNode.LocalName}");
                Console.WriteLine($"\tName: {root.ParentNode.Name}");
                Console.WriteLine($"\tNodeType: {root.ParentNode.NodeType}");

                Console.WriteLine($"\nChildNodes:");
                // підвузли
                foreach (XmlNode elem in root.ChildNodes)
                {
                    Console.WriteLine($"\n\tLocalName: {elem.LocalName}");
                    Console.WriteLine($"\tName: {elem.Name}");
                    Console.WriteLine($"\tNodeType: {elem.NodeType}");
                    Console.WriteLine($"\tInnerText: {elem.InnerText}");
                } 
#endif
#if false
                using (XmlTextReader xmlReader = new XmlTextReader(stream))
                {
                    while (xmlReader.Read())
                    {
                        string s = new StringBuilder($"LocalName: {xmlReader.LocalName}\n")
                            .Append($"Name: {xmlReader.Name}\n")
                            .Append($"NodeType: {xmlReader.NodeType}\n")
                            .Append($"Value: {xmlReader.Value}\n")
                            .Append($"ValueType: {xmlReader.ValueType}\n")
                            .ToString();

                        Console.WriteLine("\n" + s);
                    }
                } 
#endif
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
