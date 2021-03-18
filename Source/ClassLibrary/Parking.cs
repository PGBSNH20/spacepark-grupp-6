using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Parking
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public decimal MaxLength { get; set; }
        public bool Occupied { get; set; }
        public string User { get; set; }

        public static void Park(ShipResult ship)
        {
            var context = new SpaceContext();
            Console.Clear();
            Console.WriteLine("Loading...");
            var parkings = ParkingLots();
            Console.Clear();
            var selectedOption = Menu.ShowMenu($"You have selected to park {ship.Name}. Choose parking spot", new[]
            {
                $"Parking Spot {parkings.Result[0].Id}. Max ship length: {parkings.Result[0].MaxLength}m. Fee: {parkings.Result[0].Fee} credits.",
                $"Parking Spot {parkings.Result[1].Id}. Max ship length: {parkings.Result[1].MaxLength}m. Fee: {parkings.Result[1].Fee} credits.",
                $"Parking Spot {parkings.Result[2].Id}. Max ship length: {parkings.Result[2].MaxLength}m. Fee: {parkings.Result[2].Fee} credits.",
                $"Parking Spot {parkings.Result[3].Id}. Max ship length: {parkings.Result[3].MaxLength}m. Fee: {parkings.Result[3].Fee} credits.",
                $"Parking Spot {parkings.Result[4].Id}. Max ship length: {parkings.Result[4].MaxLength}m. Fee: {parkings.Result[4].Fee} credits."
            });
            switch (selectedOption)
            {
                case 0:
                    if (CheckSize(parkings, 0, ship))
                    {
                        Console.WriteLine("Too big.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        if (CanPark(parkings, 0))
                        {
                            Console.WriteLine("Occupied");
                            break;
                        }
                        Park(parkings, 0, ship);
                        break;
                    }
                case 1:
                    if (CheckSize(parkings, 1, ship))
                    {
                        Console.WriteLine("Too big.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        if (CanPark(parkings, 1))
                        {
                            Console.WriteLine("Occupied");
                            break;
                        }
                        Park(parkings, 1, ship);
                        break;
                    }

            }
        }

        public static bool CheckSize(Task<List<Parking>> parkings, int index, ShipResult ship)
        {
            return ship.Length <= parkings.Result[0].MaxLength;
        }

        public static async Task<List<Parking>> ParkingLots()
        {
            await using var context = new SpaceContext();
            var parkings = context.Parkings.OrderBy(i => i.Id).ToList();
            return parkings;
        }

        public static bool CanPark(Task<List<Parking>> parkings, int index)
        {
            using var context = new SpaceContext();
            var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
            return park.Occupied;
        }

        public static void Park(Task<List<Parking>> parkings, int index, ShipResult ship)
        {
            using var context = new SpaceContext();
            Console.WriteLine("Parked");
            var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
            park.Occupied = true;
            park.User = ship.Name;
            context.SaveChanges();
            Console.ReadKey();
        }
    }


}
