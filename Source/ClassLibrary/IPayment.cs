using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IPayment
    {
        public void Pay(Task<List<Parking>> parkings, int index, string name);
        public void Receipts();
    }
}