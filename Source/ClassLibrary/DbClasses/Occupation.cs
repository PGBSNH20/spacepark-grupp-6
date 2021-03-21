using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Occupation
    {
        public static bool AllParksOccupied()
        {
            using var context = new SpaceContext();
            StandardMessages.LoadingMessage();
            if (!context.Parkings.All(i => i.Occupied)) return false;
            StandardMessages.FullParkMessage();
            return true;
        }
        public static bool ParkIsOccupied(Task<List<IParking>> parkings, int index)
        {
            using var context = new SpaceContext();
            var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
            return park.Occupied;
        }
    }
}
