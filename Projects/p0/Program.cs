using System;
using System.Linq;

namespace p0
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using (var db = new BusinessContext())
            {
                Customer customer = new Customer { CustomerId = 1, FirstName = "Steve", LastName = "Jobs" };
                db.Customers.Add(customer);
                db.SaveChanges();
                // Console.WriteLine(db.Customers.Count());
                // Console.WriteLine(db.Customers.ToList().First().CustomerId);
            }
            Console.WriteLine("Something");

        }
    }
}
