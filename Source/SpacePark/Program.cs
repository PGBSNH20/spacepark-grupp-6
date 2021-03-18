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
                    "Exit Menu"
                });
                switch (selectedOption)
                {
                    case 0:
                        var context = new SpaceContext();
                        Console.WriteLine("Loading...");
                        if (context.Parkings.All(i => i.Occupied))
                        {
                            Console.Clear();
                            Console.WriteLine("Parking is full. Go away. Press ENTER.");
                            Console.ReadKey();
                            break;
                        }
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
