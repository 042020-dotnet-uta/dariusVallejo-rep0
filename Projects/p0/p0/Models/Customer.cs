using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// Customer model class, 
    /// </summary>
    public class Customer
    {
        // Keys / columns required to be public
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string password { get; set; }
        // public Location defaultLocation { get; set; }

        // Foreign key(s)
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Returns specific fields of the model as a string
        /// </summary>
        /// <returns>A string containing model values</returns>
        public override string ToString()
        {
            return CustomerId + " " + FirstName + " " + LastName;
        }
    }
}
