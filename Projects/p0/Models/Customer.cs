using System.Collections.Generic;

namespace p0
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string password { get; set; }
        // public Location defaultLocation { get; set; }

        // FK(s)
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return CustomerId + " " + FirstName + " " + LastName;
        }
    }
}
