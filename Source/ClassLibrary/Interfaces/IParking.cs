using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IParking
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public decimal MaxLength { get; set; }
        public bool Occupied { get; set; }
        public string User { get; set; }
        public void Park(IShipResult ship);
        public Task<List<IParking>> ParkingLots();
        public void LeavePark();
    }
}