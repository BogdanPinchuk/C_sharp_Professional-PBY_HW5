using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення .xml файла
            using (XmlTextWriter xmlFile = new XmlTextWriter("TelephoneBook.xml", Encoding.Unicode))
            {
                // включаєм форматування
                xmlFile.Formatting = Formatting.Indented;

                // заголовок
                xmlFile.WriteStartDocument();

                // корнєвий елемент
                {
                    xmlFile.WriteStartElement("MyContacts");
                    // тег
                    {
                        xmlFile.WriteStartElement("Contact");
                        {
                            // Атрибут
                            xmlFile.WriteStartAttribute("TelephoneNumber");
                            {
                                // Ім'я
                                xmlFile.WriteString("Bohdan");
                            }
                            xmlFile.WriteEndAttribute();
                            xmlFile.WriteString("+380 (63) 12 34 567");
                        }
                        xmlFile.WriteEndElement();
                    }
                    // тег
                    {
                        xmlFile.WriteStartElement("Contact");
                        {
                            xmlFile.WriteStartAttribute("TelephoneNumber");
                            {
                                // Ім'я
                                xmlFile.WriteString("Elena");
                            }
                            xmlFile.WriteEndAttribute();
                            xmlFile.WriteString("+380 (64) 12 34 567");
                        }
                        xmlFile.WriteEndElement();
                    }
                    xmlFile.WriteEndElement();
                }
                xmlFile.WriteEndDocument();
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
