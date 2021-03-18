using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using RestSharp;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            var r = Person.GetPerson();
            var ship = Starship.GetStarships();

            Console.WriteLine(ship.Result.Count);
            Console.WriteLine(r.Result.Count);

            if (r.Result.Any(p => p.Name == name))
            {
                Console.WriteLine($"Welcome {name}. What ship will you be parking today?");
                foreach (var s in ship.Result)
                {
                    Console.WriteLine("Name: " + s.Name + " Length: " + s.Length);
                }
            }
            else
            {
                Console.WriteLine("Not Allowed");
            }

        }
    }
}
