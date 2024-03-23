namespace Sol_server_api.Entities
{
    public class Component
    {
        public string ComponentID { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string StockStatus { get; set; } = string.Empty; //Missing/Ordered/Arrived/InCompartment/InPackage
        
        
        public string? FKPackageID { get; set; } //FK
        // public virtual ProjectPackage? ProjectPackage { get; set; }
        
        public string? CompartmentID { get; set; }
        public virtual Compartment? Compartment { get; set; }
    }
}
