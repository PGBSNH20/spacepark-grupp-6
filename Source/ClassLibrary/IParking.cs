using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IParking
    {
        public void Park(ShipResult ship);
        public Task<List<Parking>> ParkingLots();
        public void LeavePark();
    }
}