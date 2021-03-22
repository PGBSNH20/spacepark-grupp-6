using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IPayment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string User { get; set; }
        public DateTime PayDate { get; set; }
        public void Pay(Task<List<IParking>> parkings, int index, string name);
        public void Receipts();
    }
}