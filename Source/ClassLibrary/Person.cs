using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Person
    {
        public string Count { get; set; }
        public List<Results> Results { get; set; }
        public static async Task<List<Results>> GetPerson()
        {
            var list = new List<string>();
            string id;
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var response = await client.GetAsync<Person>(request);

            //for (int i = 0; i < response.Results.Count; i++)
            //{
            //    for (int j = 0; j < response.Results[i].Starships.Count; j++)
            //    {
            //        var s = response.Results[i].Starships[j].Split("/");
            //        id = s[5];
            //        var t = await Starship.GetStarships(id);
            //        foreach (var ship in t)
            //        {
            //            response.Results[i].Ships.Add(ship);
            //        }
            //    }

            //}

            return response.Results;
        }
    }
    public class Results
    {
        public string Name { get; set; }
        public string Height { get; set; }
    }
}
