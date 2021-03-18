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
        //    var t = Starship.GetStarships("22");
        //    Console.WriteLine(t.Result);
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            var r = Person.GetPerson();
            var ship = Starship.GetStarships();

            Console.WriteLine(r.Result.Count);

            if (r.Result.Any(p => p.Name == name))
            {
                Console.WriteLine($"Welcome {name}. What ship will you be parking today?");
                //ListShips();
            }
            else
            {
                Console.WriteLine("Not Allowed");
            }

        }
    }
}
