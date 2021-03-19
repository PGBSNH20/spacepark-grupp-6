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
                Console.WriteLine(@" ________  ________  ________  ________  _______           ________  ________  ________  ___  __       
|\   ____\|\   __  \|\   __  \|\   ____\|\  ___ \         |\   __  \|\   __  \|\   __  \|\  \|\  \     
\ \  \___|\ \  \|\  \ \  \|\  \ \  \___|\ \   __/|        \ \  \|\  \ \  \|\  \ \  \|\  \ \  \/  /|_   
 \ \_____  \ \   ____\ \   __  \ \  \    \ \  \_|/__       \ \   ____\ \   __  \ \   _  _\ \   ___  \  
  \|____|\  \ \  \___|\ \  \ \  \ \  \____\ \  \_|\ \       \ \  \___|\ \  \ \  \ \  \\  \\ \  \\ \  \ 
    ____\_\  \ \__\    \ \__\ \__\ \_______\ \_______\       \ \__\    \ \__\ \__\ \__\\ _\\ \__\\ \__\
   |\_________\|__|     \|__|\|__|\|_______|\|_______|        \|__|     \|__|\|__|\|__|\|__|\|__| \|__|
   \|_________|                                                                                        
                                   ");

                Console.WriteLine("");
                var selectedOption = Menu.ShowMenu("SpacePark Menu", new[]
                {
                    "Park Ship",
                    "Leave SpacePark",
                    "Show receipts",
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
                        Parking.LeavePark();
                        break;
                    case 2:
                        Payment.Receipts();
                        break;
                    case 3:
                        running = false;
                        break;
                }
            }
        }
        

        
    }
}
