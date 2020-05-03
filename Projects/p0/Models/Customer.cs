using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Order> orders { get; set; }
        // public string password { get; set; }
        // public Location defaultLocation { get; set; }

        public override string ToString()
        {
            return CustomerId + " " + firstName + " " + lastName;
        }
    }
}
