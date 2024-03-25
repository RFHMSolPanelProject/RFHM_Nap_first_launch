namespace Sol_server_api.Entities
{
    public class ProjectPackage
    {
        public string PackageID { get; set; } = string.Empty;
        public string RequiredComponentName { get; set; } = string.Empty;   
        public int RequiredPiece { get; set; }
        bool forDelivery { get; set; } = false;

        public string FKProjectID { get; set; } = string.Empty; //FK

        public ICollection<Component>? Components { get; set; }
    }
}
