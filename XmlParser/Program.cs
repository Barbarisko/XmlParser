using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using XMLClasses.Models;

namespace XmlParser
{
    class Program
    {
        private static string SchemaUri = "Candies.xsd";
        private static string XmlPath = "Candies.xml";
        private const string TargetNamespace = "http://www.mydomain/candies";

        static void Main(string[] args)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(TargetNamespace, SchemaUri);

            var settings = new XmlReaderSettings
            {
                Schemas = schemas,
                ValidationType = ValidationType.Schema,
                ValidationFlags =
                    XmlSchemaValidationFlags.ProcessIdentityConstraints |
                    XmlSchemaValidationFlags.ReportValidationWarnings
            };
            settings.ValidationEventHandler += new ValidationEventHandler(SchemaValidationEventHandler);

            using var input = new StreamReader(XmlPath);
            using XmlReader reader = XmlReader.Create(input, settings);
            XmlSerializer serializer = new XmlSerializer(typeof(Candies));

            Candies candies = (Candies)serializer.Deserialize(reader);
            if (candies != null && candies.Candy.Any())
            {
                var candiesList = candies.Candy.ToList();
                candiesList.Sort();

                PrintCandies(candiesList);
                SerializeJson(candiesList);
            }
        }

        private static void PrintCandies(List<Candy> candies)
        {
            for (int i = 0; i < candies.Count; i++)
            {
                Console.WriteLine($"Candy {i}: {candies[i]}");
            }
        }


        private static void SerializeJson(List<Candy> candies)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(candies, Newtonsoft.Json.Formatting.Indented); ;

            Console.WriteLine(jsonString);
        }

        static void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\nError: {0}", e.Message, Color.AntiqueWhite);
                    Console.ResetColor();
                    throw new Exception(e.Message);
                case XmlSeverityType.Warning:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nWarning: {0}", e.Message, Color.Brown);
                    Console.ResetColor();
                    throw new Exception(e.Message);
            }
        }
    }
}
