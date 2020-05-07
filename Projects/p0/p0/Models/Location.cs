using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// Model representing a store location
    /// </summary>
    public class Location
    {
        // Keys / columns required to be public
        public string LocationId { get; set; }
        public string LocationName { get; set; }

        // Foreign keys(s)
        public List<Inventory> Inventories { get; set; }
    }
}
