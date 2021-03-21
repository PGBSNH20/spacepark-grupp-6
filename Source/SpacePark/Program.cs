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

            var running = true;
            while (running)
            {
                StandardMessages.StartMessage();
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
                        if (Occupation.AllParksOccupied()) break;
                        var ship = starship.SelectShip();
                        if (ship == null) break;
                        parking.Park(ship);
                        break;
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
