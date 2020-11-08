using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Adressbok
{
    class Program
    {
        public class Person
        {
            //Konstruktor tagen från https://stackoverflow.com/questions/8391885/storing-data-into-list-with-class
            public string namn { set; get; }
            public string adress { set; get; }
            public string phone { set; get; }
            public string email { set; get; }
        }
        static void Main(string[] args)
        {
            string input;
            List<Person> people = new List<Person>();
            string[] transfer = File.ReadAllLines(@"C:\Users\Dator 1\Adressbok.txt");
            string[] toFile = new string[4];
            for (int i = 0; i < transfer.Length - 1; i += 4)
            {
                people.Add(new Person { namn = transfer[i], adress = transfer[i + 1], phone = transfer[i + 2], email = transfer[i + 3] });
            }
            Console.WriteLine("Välkommen till programmet.");
            do
            {
                Console.Write(">");
                input = Console.ReadLine();
                if (input == "ny")
                {
                    Console.Write("Vad heter personen du vill lägga till:");
                    toFile[0] = Console.ReadLine();
                    Console.Write("Vart bor personen du vill lägga till:");
                    toFile[1] = Console.ReadLine();
                    Console.Write("Vad är personens telefonnummer:");
                    toFile[2] = Console.ReadLine();
                    Console.Write("Vad är personens e-mail:");
                    toFile[3] = Console.ReadLine();
                    people.Add(new Person { namn = toFile[0], adress = toFile[1], phone = toFile[2], email = toFile[3] });
                    File.AppendAllLines(@"C:\Users\Dator 1\Adressbok.txt", toFile);
                }
                else if (input == "visa")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.Write($"{people[i].namn}, {people[i].adress}, {people[i].phone}, {people[i].email}.");
                        Console.WriteLine();
                    }
                }
            } while (input != "sluta");
            Console.WriteLine("Hej då!");
        }
    }
}
