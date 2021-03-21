using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IPerson
    {
        public Task<List<Results>> GetPerson();
    }
}