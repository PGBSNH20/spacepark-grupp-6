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

            Console.WriteLine(r.Result.Any(p => p.Name == name) ? "Welcome" : "Not Allowed");
        }
    }
}
