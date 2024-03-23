namespace Sol_server_api.Entities
{
    public class Permission
    {
        public string PermissionID { get; set; } = string.Empty;
        public string PermissionDesc { get; set; } = string.Empty ;
        public string PermissionName { get; set; } = string.Empty;

        public string FKCoworkerID { get; set; } = string.Empty;    
        //public virtual Coworker? Coworker { get; set; } 
    }
}
