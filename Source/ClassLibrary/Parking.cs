using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Parking : IParking
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public decimal MaxLength { get; set; }
        public bool Occupied { get; set; }
        public string User { get; set; }

        public void Park(ShipResult ship)
        {
            Console.Clear();
            Console.WriteLine("Loading...");
            var parkings = ParkingLots();
            Console.Clear();
            var selectedOption = Menu.ShowMenu($"You have selected to park {ship.Name}. Choose parking spot", new[]
            {
                $"Parking Spot {parkings.Result[0].Id}. Max ship length: {parkings.Result[0].MaxLength}m. Fee: {parkings.Result[0].Fee} credits. Occupied? {parkings.Result[0].Occupied}",
                $"Parking Spot {parkings.Result[1].Id}. Max ship length: {parkings.Result[1].MaxLength}m. Fee: {parkings.Result[1].Fee} credits. Occupied? {parkings.Result[1].Occupied}",
                $"Parking Spot {parkings.Result[2].Id}. Max ship length: {parkings.Result[2].MaxLength}m. Fee: {parkings.Result[2].Fee} credits. Occupied? {parkings.Result[2].Occupied}",
                $"Parking Spot {parkings.Result[3].Id}. Max ship length: {parkings.Result[3].MaxLength}m. Fee: {parkings.Result[3].Fee} credits. Occupied? {parkings.Result[3].Occupied}",
                $"Parking Spot {parkings.Result[4].Id}. Max ship length: {parkings.Result[4].MaxLength}m. Fee: {parkings.Result[4].Fee} credits. Occupied? {parkings.Result[4].Occupied}"
            });
            switch (selectedOption)
            {
                case 0:
                    Finish(parkings, 0, ship);
                    break;
                case 1:
                    Finish(parkings, 1, ship);
                    break;
                case 2:
                    Finish(parkings, 2, ship);
                    break;
                case 3:
                    Finish(parkings, 3, ship);
                    break;
                case 4:
                    Finish(parkings, 4, ship);
                    break;
            }
        }

        private bool SizeTooBig(Task<List<Parking>> parkings, int index, ShipResult ship)
        {
            return ship.Length > parkings.Result[index].MaxLength;
        }

        public async Task<List<Parking>> ParkingLots()
        {
            await using var context = new SpaceContext();
            var parkings = context.Parkings.OrderBy(i => i.Id).ToList();
            return parkings;
        }
        private bool ParkIsOccupied(Task<List<Parking>> parkings, int index)
        {
            using var context = new SpaceContext();
            var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
            return park.Occupied;
        }

        private void Park(Task<List<Parking>> parkings, int index, ShipResult ship)
        {
            Console.Clear();
            using var context = new SpaceContext();
            Console.WriteLine("Parking..");
            var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
            park.Occupied = true;
            park.User = ship.Name;
            context.SaveChangesAsync();
            Console.WriteLine("Parked");
            Console.ReadKey();
        }

        private void Finish(Task<List<Parking>> parkings, int index, ShipResult ship)
        {
            if (SizeTooBig(parkings, index, ship))
            {
                Console.WriteLine("Too big.");
                Console.ReadKey();
            }
            else
            {
                if (ParkIsOccupied(parkings, index))
                {
                    Console.WriteLine("Occupied");
                    Console.ReadKey();
                }
                else
                {
                    Park(parkings, index, ship);
                }
            }
        }

        public void LeavePark()
        {
            IPerson person = new Person();
            IPayment payment = new Payment();
            Console.Clear();
            Console.WriteLine("For security reasons, provide your name before selecting your ship.");
            string name = Console.ReadLine();
            var r = person.GetPerson();
            Console.WriteLine("Loading...");
            if (r.Result.Any(p => p.Name == name))
            {
                var parkings = ParkingLots();
                Console.Clear();
                var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be leaving with today?\n", new[]
                {
                    $"Parking Spot {parkings.Result[0].Id}. Is occupied: {parkings.Result[0].Occupied}. Occupied by {parkings.Result[0].User}",
                    $"Parking Spot {parkings.Result[1].Id}. Is occupied: {parkings.Result[1].Occupied}. Occupied by {parkings.Result[1].User}",
                    $"Parking Spot {parkings.Result[2].Id}. Is occupied: {parkings.Result[2].Occupied}. Occupied by {parkings.Result[2].User}",
                    $"Parking Spot {parkings.Result[3].Id}. Is occupied: {parkings.Result[3].Occupied}. Occupied by {parkings.Result[3].User}",
                    $"Parking Spot {parkings.Result[4].Id}. Is occupied: {parkings.Result[4].Occupied}. Occupied by {parkings.Result[4].User}",
                });

                switch (selectedOption)
                {
                    case 0:
                        if (ParkIsOccupied(parkings, 0) == false)
                        {
                            Console.WriteLine("You cannot leave with nothing?");
                            Console.ReadKey();
                            break;
                        }
                        payment.Pay(parkings, 0, name);
                        Leave(parkings, 0);
                        break;
                    case 1:
                        if (ParkIsOccupied(parkings, 1) == false)
                        {
                            Console.WriteLine("You cannot leave with nothing?");
                            Console.ReadKey();
                            break;
                        }
                        payment.Pay(parkings, 1, name);
                        Leave(parkings, 1);
                        break;
                    case 2:
                        if (ParkIsOccupied(parkings, 2) == false)
                        {
                            Console.WriteLine("You cannot leave with nothing?");
                            Console.ReadKey();
                            break;
                        }
                        payment.Pay(parkings, 2, name);
                        Leave(parkings, 2);
                        break;
                    case 3:
                        if (ParkIsOccupied(parkings, 3) == false)
                        {
                            Console.WriteLine("You cannot leave with nothing?");
                            Console.ReadKey();
                            break;
                        }
                        payment.Pay(parkings, 3, name);
                        Leave(parkings, 3);
                        break;
                    case 4:
                        if (ParkIsOccupied(parkings, 4) == false)
                        {
                            Console.WriteLine("You cannot leave with nothing?");
                            Console.ReadKey();
                            break;
                        }
                        payment.Pay(parkings, 4, name);
                        Leave(parkings, 4);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Not Allowed");
                Console.ReadKey();
            }
        }
        private void Leave(Task<List<Parking>> parkings, int index)
        {
            using var context = new SpaceContext();
            Console.WriteLine("Leaving...");
            var ship = context.Parkings.First(s => s.Id == parkings.Result[index].Id);
            ship.Occupied = false;
            ship.User = null;
            context.SaveChangesAsync();
            Console.Clear();
            Console.WriteLine("Left.");
            Console.ReadKey();
        }
    }
}
