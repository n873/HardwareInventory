using System;

namespace HardwareInventory.Domain.Model
{
    public interface IInventoryItem 
    {
        DateTime AssignedDate { get; set; }
        string AssignedTo { get; set; }
        string Comments { get; set; }
        decimal Cost { get; set; }
        string Location { get; set; }
        DateTime PurchaseDate { get; set; }
        string Supplier { get; set; }
    }
}