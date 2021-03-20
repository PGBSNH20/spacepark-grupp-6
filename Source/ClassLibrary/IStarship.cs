using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IStarship
    {
        public List<ShipResult> Results { get; set; }
        public Task<List<ShipResult>> GetStarships();
        public ShipResult SelectShip();
    }
}