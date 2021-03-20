using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using RestSharp;

namespace SpacePark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IParking parking = new Parking();
            IPayment payment = new Payment();
            IStarship starship = new Starship();

            Console.Clear();
            var running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(@" ____  ____   _    ____ _____   ____   _    ____  _  __
/ ___||  _ \ / \  / ___| ____| |  _ \ / \  |  _ \| |/ /
\___ \| |_) / _ \| |   |  _|   | |_) / _ \ | |_) | ' / 
 ___) |  __/ ___ | |___| |___  |  __/ ___ \|  _ <| . \ 
|____/|_| /_/   \_\____|_____| |_| /_/   \_|_| \_|_|\_\");

                Console.WriteLine("");
                var selectedOption = Menu.ShowMenu("SpacePark Menu", new[]
                {
                    "Park Ship",
                    "Leave SpacePark",
                    "Show Receipts",
                    "Exit Menu"
                });
                switch (selectedOption)
                {
                    case 0:
                        {
                            using var context = new SpaceContext();
                            Console.WriteLine("Loading...");
                            if (context.Parkings.All(i => i.Occupied))
                            {
                                Console.Clear();
                                Console.WriteLine("Parking is full. Go away. Press ENTER.");
                                Console.ReadKey();
                                break;
                            }
                            Console.Clear();
                            var ship = starship.SelectShip();
                            parking.Park(ship);
                            break;
                        }
                    case 1:
                        parking.LeavePark();
                        break;
                    case 2:
                        payment.Receipts();
                        break;
                    case 3:
                        running = false;
                        break;
                }
            }
        }



    }
}
