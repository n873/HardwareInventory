namespace HardwareInventory.Domain.Model
{
    public interface IInventory
    {
        int Id { get; set; }
        string Type{ get; set; }
        string Description { get; set; }
    }
}
