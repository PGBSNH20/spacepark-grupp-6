using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Starship
    {
        public string Name { get; set; }
        public string Length { get; set; }
        public List<ShipResult> Results { get; set; }

        public static async Task<List<ShipResult>> GetStarships()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = await client.GetAsync<Starship>(request);
            return response.Results;
        }
    }
    public class ShipResult
    {
        public string Name { get; set; }
        public string Length { get; set; }
    }
}