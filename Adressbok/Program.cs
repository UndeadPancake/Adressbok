using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok
{
    class Program
    {
        class Person
        {
            static public string namn;
            static public string adress;
            static public string phone;
            static public string email;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till programmet.");
            string input = Console.ReadLine();
            do
            {
                input = Console.ReadLine();
            } while (input != "sluta");
        }
    }
}
