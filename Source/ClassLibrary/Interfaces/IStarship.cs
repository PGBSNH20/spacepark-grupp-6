using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IStarship
    {
        public Task<List<ShipResult>> GetStarships();
        public IShipResult SelectShip();
    }
}