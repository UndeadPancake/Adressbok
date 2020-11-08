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
            int remove;
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
                else if (input == "ta bort")
                {
                    Console.Write("Vilken person vill du ta ut ur din adressbok:");
                    remove = int.Parse(Console.ReadLine());
                    people.RemoveAt(remove);
                    string[] newFile = new string[people.Count * 4];
                    Person[] middleMan = new Person[people.Count];
                    middleMan = people.ToArray();
                    for (int i = 0; i < newFile.Length; i += 4)
                    {
                        newFile[i] = middleMan[i / 4].namn;
                    }
                    for (int i = 1; i < newFile.Length; i += 4)
                    {
                        newFile[i] = middleMan[i / 4].adress;
                    }
                    for (int i = 2; i < newFile.Length; i += 4)
                    {
                        newFile[i] = middleMan[i / 4].phone;
                    }
                    for (int i = 3; i < newFile.Length; i += 4)
                    {
                        newFile[i] = middleMan[i / 4].email;
                    }
                    File.WriteAllLines(@"C:\Users\Dator 1\Adressbok.txt", newFile);
                }
            } while (input != "sluta");
            Console.WriteLine("Hej då!");
        }
    }
}
