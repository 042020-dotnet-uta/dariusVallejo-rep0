namespace p0
{
    /// <summary>
    /// Model representing overall inventory across the business
    /// </summary>
    public class Inventory
    {
        // Keys / columns required to be public
        public string InventoryId { get; set; }
        public int Quantity { get; set; }

        // Foreign keys(s)
        public string LocationId { get; set; }
        public string ProductId { get; set; }
    }
}
