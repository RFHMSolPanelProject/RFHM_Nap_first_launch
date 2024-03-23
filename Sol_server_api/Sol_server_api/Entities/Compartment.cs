namespace Sol_server_api.Entities
{
    public class Compartment
    {
        public string CompartmentID { get; set; } = string.Empty;
        public string? StoragedComponentName { get; set; }
        public int Row { get; set; } 
        public int Col { get; set; } 
        public int Bracket { get; set; }
        public int MaximumPiece {  get; set; }
        public int? StoragedPiece { get; set; }
        
        public string? FKComponentID { get; set; } = string.Empty;//FK
        //public virtual Component? Component { get; set; }
    }
}
