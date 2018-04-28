using System;

namespace XmlStreamParser
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var information = new XmlParser("lab4.xml");

            Console.WriteLine($"Średnia wieku kobiety to : {information.AvgAge(Gender.Female)}");
            Console.WriteLine($"Średnia wieku mężczyzny to: {information.AvgAge(Gender.Male)}");
        }
    }
}
