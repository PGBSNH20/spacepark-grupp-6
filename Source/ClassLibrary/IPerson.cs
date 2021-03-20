using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IPerson
    {
        public int Id { get; set; }
        public string Count { get; set; }
        public List<Results> Results { get; set; }
        public Task<List<Results>> GetPerson();
    }
}