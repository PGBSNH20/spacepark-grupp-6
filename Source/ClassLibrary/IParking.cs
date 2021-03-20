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
        public void Park(ShipResult ship);
        public bool SizeTooBig(Task<List<Parking>> parkings, int index, ShipResult ship);
        public Task<List<Parking>> ParkingLots();
        public bool ParkIsOccupied(Task<List<Parking>> parkings, int index);
        public void Park(Task<List<Parking>> parkings, int index, ShipResult ship);
        public void Finish(Task<List<Parking>> parkings, int index, ShipResult ship);
        public void LeavePark();
        public void Leave(Task<List<Parking>> parkings, int index);
    }
}