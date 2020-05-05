using System.Collections.Generic;

namespace p0
{
    public class Location
    {
        public string LocationId { get; set; }
        public string locationName { get; set; }
        public List<Inventory> inventory { get; set; }
    }
}
