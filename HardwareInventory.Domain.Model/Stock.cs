﻿namespace HardwareInventory.Domain.Model
{
    public abstract class Stock : IInventory
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
    }
}
