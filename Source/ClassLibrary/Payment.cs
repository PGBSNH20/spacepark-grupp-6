using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string User { get; set; }

        public static void Pay(Task<List<Parking>> parkings, int index, string name)
        {
            Console.Clear();
            using var context = new SpaceContext();
            Console.WriteLine("Using swish to pay...");
            var pay = new Payment()
            {
                Amount = parkings.Result[index].Fee,
                User = name
            };
            context.Add(pay);
            context.SaveChanges();
            Console.WriteLine("Payment successful");
            Console.ReadKey();
        }

        public static void Receipts()
        {
            using var context = new SpaceContext();
            Console.Clear();
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();
            var payments = context.Payments.Where(p => p.User == name).ToList();
            if (!payments.Any())
            {
                Console.WriteLine("No receipts found.");
            }
            else
            {
                foreach (var r in payments)
                {
                    Console.WriteLine($"Payment by {r.User}. Amount {r.Amount} credits.");
                }
            }
            

            Console.ReadKey();
        }
    }
}
