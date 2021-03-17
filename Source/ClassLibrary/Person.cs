using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Person
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public List<Results> Results { get; set; }

        public static async Task<List<Results>> GetPerson()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var response = await client.GetAsync<Person>(request);
            return response.Results;
        }
    }
    public class Results
    {
        public string Name { get; set; }
        public string Height { get; set; }


    }
    public class Starship
    {
        public string Name { get; set; }
        public string Length { get; set; }
    }

}
