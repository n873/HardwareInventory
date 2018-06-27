using System;

namespace HardwareInventory.Domain.Model
{
    public class InventoryItem : Inventory, IInventoryItem
    {
        public string Code { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string AssignedTo { get; set; }
        public DateTime AssignedDate { get; set; }
        public decimal Cost { get; set; }
        public string Location { get; set; }
        public string Supplier { get; set; }
        public string Comments { get; set; }
    }
}
