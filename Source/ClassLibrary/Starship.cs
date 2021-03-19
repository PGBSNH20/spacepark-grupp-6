using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Starship
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
        public List<ShipResult> Results { get; set; }

        public static async Task<List<ShipResult>> GetStarships()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = await client.GetAsync<Starship>(request);
            return response.Results;
        }
        public static ShipResult SelectShip()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            var r = Person.GetPerson();
            var ship = GetStarships();
            Console.WriteLine("Loading...");
            if (r.Result.Any(p => p.Name == name))
            {
                Console.Clear();
                var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be parking today?\n", new[]
                {
                    ship.Result[0].Name + $" ({ship.Result[0].Length}m)",
                    ship.Result[1].Name + $" ({ship.Result[1].Length}m)",
                    ship.Result[2].Name + $" ({ship.Result[2].Length}m)",
                    ship.Result[3].Name + $" ({ship.Result[3].Length}m)",
                    ship.Result[4].Name + $" ({ship.Result[4].Length}m)",
                    ship.Result[5].Name + $" ({ship.Result[5].Length}m)",
                    ship.Result[6].Name + $" ({ship.Result[6].Length}m)",
                    ship.Result[7].Name + $" ({ship.Result[7].Length}m)",
                    ship.Result[8].Name + $" ({ship.Result[8].Length}m)",
                    ship.Result[9].Name + $" ({ship.Result[9].Length}m)",
                });
                switch (selectedOption)
                {
                    case 0:
                        return ship.Result[0];
                    case 1:
                        return ship.Result[1];
                    case 2:
                        return ship.Result[2];
                    case 3:
                        return ship.Result[3];
                    case 4:
                        return ship.Result[4];
                    case 5:
                        return ship.Result[5];
                    case 6:
                        return ship.Result[6];
                    case 7:
                        return ship.Result[7];
                    case 8:
                        return ship.Result[8];
                    case 9:
                        return ship.Result[9];
                }
            }
            else
            {
                Console.WriteLine("Not Allowed");
                return null;
            }

            return null;
        }
    }
    public class ShipResult
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
    }
}