using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Count { get; set; }
        public List<Results> Results { get; set; }
        public async Task<List<Results>> GetPerson()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var response = await client.GetAsync<Person>(request);
            return response.Results;
        }
    }

    public class Results
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
    }
}
