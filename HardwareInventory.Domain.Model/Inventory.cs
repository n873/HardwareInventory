namespace HardwareInventory.Domain.Model
{
    public abstract class Inventory : IInventory
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public bool Deleted { get; set; }
        public bool DeletedBy { get; set; }
    }
}
