namespace p0
{
    public class Inventory
    {
        public string InventoryId { get; set; }
        public int Quantity { get; set; }

        // FK(s)
        public string LocationId { get; set; }
        public string ProductId { get; set; }
    }
}
