using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Starship : IStarship
    {
        public List<ShipResult> Results { get; set; }

        public async Task<List<ShipResult>> GetStarships()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = await client.GetAsync<Starship>(request);
            return response.Results;
        }

        public IShipResult SelectShip()
        {
            IPerson person = new Person();
            string name = StandardMessages.NameReader();
            var apiResult = person.GetPerson();
            var shipResult = GetStarships();
            var array = ArrayBuilder.ShipArray(shipResult);

            if (apiResult.Result.Any(p => p.Name == name))
            {
                Console.Clear();
                var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be parking today?\n", array);
                return shipResult.Result.Where((_, i) => selectedOption == i).FirstOrDefault();
            }
            StandardMessages.NotAllowedMessage();
            return null;
        }
    }
}