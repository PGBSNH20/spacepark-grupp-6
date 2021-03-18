using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using RestSharp;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("");
                var selectedOption = Menu.ShowMenu("SpacePark Menu", new[]
                {
                    "Park Ship",
                    "Leave SpacePark",
                    "Exit"
                });
                switch (selectedOption)
                {
                    case 0:
                        Console.Clear();
                        var ship = Starship.SelectShip();
                        Parking.Park(ship);
                        break;
                    case 1:
                        Console.WriteLine("Temp");
                        break;
                    case 2:
                        running = false;
                        break;
                }
            }
        }
        

        
    }
}
